using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagement.BlazorUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var isTokenPresent = await localStorage.ContainKeyAsync("token");
            if (isTokenPresent == false)
            {
                //If token not present, returning user with blank AuthenticationState
                return new AuthenticationState(user);
            }

            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            //Parsing token to see if the token is valid
            if (tokenContent.ValidTo < DateTime.UtcNow)
            {
                //If invalid, remove token from storage and still return blank user in AuthenticationState
                await localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            //Valid user
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            //Return that person
            return new AuthenticationState(user);
        }

        public async Task LoggedIn()
        {
            //Getting claims from token
            var claims = await GetClaims();
            //Creating a user based on claims
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            //Setting the authentication state for the user
            var authState = Task.FromResult(new AuthenticationState(user));
            //Raising notify event. Built-in in Blazor
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            //Remove token
            await localStorage.RemoveItemAsync("token");
            //Emptying out claimsprincipal
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            //Setting authentication state.
            var authState = Task.FromResult(new AuthenticationState(nobody));
            //Notifying it
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<List<Claim>> GetClaims()
        {
            //Fetching saved token, reading it and adding it to a list.
            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
