using Microsoft.AspNetCore.Identity;

namespace HR.LeaveManagement.Identity.Models
{
    //This is our end user object who's going to be using our application.
    //Both Sign in and signup information are going to be against this model.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
