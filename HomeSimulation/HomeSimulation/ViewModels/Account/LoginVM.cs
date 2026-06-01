using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeSimulation.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Username must contains max 30 characters"),
    MinLength(3, ErrorMessage = "Username must contains min 3 characters")]
        [EmailAddress(ErrorMessage = "Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
