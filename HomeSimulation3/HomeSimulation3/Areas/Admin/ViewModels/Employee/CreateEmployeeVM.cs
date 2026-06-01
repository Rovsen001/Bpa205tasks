using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSimulation3.Areas.Admin.ViewModels.Employee
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage ="Required")]
        [StringLength(30,ErrorMessage ="Name must contains max 30 characters"),
            MinLength(3,ErrorMessage ="Name must contains min 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Full Adress must contains max 30 characters"),
    MinLength(3, ErrorMessage = "Full Adress must contains min 3 characters")]
        public string FullAdress { get; set; }
        public int PositionId { get; set; }
        [Required(ErrorMessage ="Required")]
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
