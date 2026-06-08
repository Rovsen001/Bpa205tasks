using Microsoft.AspNetCore.Identity;

namespace Simulation6.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
