namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        //Login
        Task<bool> AuthenticateAsync(string email, string password);
        //SignUp
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        //LogOut
        Task Logout();
    }
}
