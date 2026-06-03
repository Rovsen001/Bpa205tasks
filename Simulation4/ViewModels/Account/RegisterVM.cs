using System.ComponentModel.DataAnnotations;

namespace Simulation4.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30,ErrorMessage ="Max 30 characters"),
            MinLength(3,ErrorMessage ="Min 2 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(8, ErrorMessage = "Min 2 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
