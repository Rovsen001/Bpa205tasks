using System.ComponentModel.DataAnnotations;

namespace Simulation6.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters")]
        [EmailAddress(ErrorMessage = "Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(8, ErrorMessage = "Min 8 characters")]
        public string Password { get; set; }
    }
}
