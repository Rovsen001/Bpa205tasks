using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeSimulation3.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Username must contains max 30 characters"),
         MinLength(3, ErrorMessage = "Username must contains min 3 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Username must contains max 30 characters"),
         MinLength(3, ErrorMessage = "Username must contains min 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Username must contains max 30 characters"),
         MinLength(3, ErrorMessage = "Username must contains min 3 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Username must contains max 30 characters"),
         MinLength(3, ErrorMessage = "Username must contains min 3 characters")]
        [EmailAddress(ErrorMessage = "Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
