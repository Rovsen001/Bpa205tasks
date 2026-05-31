using System.ComponentModel.DataAnnotations;

namespace HomeSimulation4.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Max 20 characters"),
            MinLength(8, ErrorMessage = "Min 8 characters")]
        public string Password { get; set; }
    }
}
