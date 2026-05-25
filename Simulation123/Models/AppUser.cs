using Microsoft.AspNetCore.Identity;
using Simulation123.Models.Base;

namespace Simulation123.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }
    }
}
