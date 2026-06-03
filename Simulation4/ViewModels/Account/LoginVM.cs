using System.ComponentModel.DataAnnotations;

namespace Simulation4.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(8, ErrorMessage = "Min 2 characters")]
        public string Password { get; set; }
    }
}
