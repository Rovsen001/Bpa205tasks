using DigiMediaTask.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DigiMediaTask.Models
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage ="Profession required...")]
        [
            StringLength(30, ErrorMessage ="Must contains max 30 characters..."),
            MinLength(3, ErrorMessage = "Must contains min 3 characters...")
            ]
        public string Profession { get; set; }
        [Required(ErrorMessage ="Category required...")]
        [
            StringLength(30, ErrorMessage = "Must contains max 30 characters..."),
            MinLength(3, ErrorMessage = "Must contains min 3 characters...")
            ]
        public string Category { get; set; }
        [Required(ErrorMessage ="Image URL required...")]
        public string ImageUrl { get; set; }
    }
}
