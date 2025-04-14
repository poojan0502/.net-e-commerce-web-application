using Microsoft.AspNetCore.Identity;

namespace Group_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
