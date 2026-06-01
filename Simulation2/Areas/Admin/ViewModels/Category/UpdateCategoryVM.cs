using System.ComponentModel.DataAnnotations;

namespace Simulation2.Areas.Admin.ViewModels.Category
{
    public class UpdateCategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Max 20 characters"),
              MinLength(3, ErrorMessage = "Min 3 characters")]
        public string Name { get; set; }
    }
}
