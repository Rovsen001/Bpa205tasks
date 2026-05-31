using System.ComponentModel.DataAnnotations;

namespace HomeSimulation4.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Required")]
        [StringLength(30,ErrorMessage ="Max 30 characters"),
            MinLength(3,ErrorMessage ="Min 3 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 3 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage ="Must be an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Max 20 characters"),
            MinLength(8, ErrorMessage = "Min 8 characters")]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
