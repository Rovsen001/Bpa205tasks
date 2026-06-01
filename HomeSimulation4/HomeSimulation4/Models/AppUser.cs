using Microsoft.AspNetCore.Identity;

namespace HomeSimulation4.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
