using System.ComponentModel.DataAnnotations;

namespace Simulation4.Areas.Admin.ViewModels.Category
{
    public class CreateCategoryVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Name { get; set; }
    }
}
