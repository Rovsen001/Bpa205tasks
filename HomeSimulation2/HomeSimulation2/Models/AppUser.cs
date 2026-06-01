using Microsoft.AspNetCore.Identity;

namespace HomeSimulation2.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
