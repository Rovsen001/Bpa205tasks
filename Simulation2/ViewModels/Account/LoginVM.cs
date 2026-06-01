using System.ComponentModel.DataAnnotations;

namespace Simulation2.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinLength(8, ErrorMessage = "Min 8 characters")]
        public string Password { get; set; }
    }
}
