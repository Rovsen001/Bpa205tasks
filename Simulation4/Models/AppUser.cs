using Microsoft.AspNetCore.Identity;

namespace Simulation4.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
