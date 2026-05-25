using AdminCRUDTask.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminCRUDTask.Models
{
    public class Slider : BaseEntity
    {
        [Required(ErrorMessage ="Title required ...")]
        [
            StringLength(30, ErrorMessage ="Title maximum contains 30 characters..."),
            MinLength(3, ErrorMessage ="Title minimum contains 3 characters...")
            ]
       public string Title {  get; set; }
        [Required(ErrorMessage = "Description required ...")]
        [
           StringLength(150, ErrorMessage = "Description maximum contains 150 characters..."),
           MinLength(3, ErrorMessage = "Description minimum contains 3 characters...")
           ]
        public string Description {  get; set; }
       public string? ImageUrl { get; set; }
        [NotMapped]
       public IFormFile ImageFile { get; set; }
    }
}
