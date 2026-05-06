using ClassTask1.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassTask1.Models
{
    public class Slider : BaseEntity
    {
        [Required(ErrorMessage ="Title required...")]
        [
            StringLength(30, ErrorMessage ="Title must contains maximum 30 characters..."),
            MinLength(3, ErrorMessage ="Title must contains minimum 3 characters...")
            ]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description required...")]
        [
    StringLength(150, ErrorMessage = "Description must contains maximum 150 characters..."),
    MinLength(10, ErrorMessage = "Description must contains minimum 10 characters...")
    ]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
