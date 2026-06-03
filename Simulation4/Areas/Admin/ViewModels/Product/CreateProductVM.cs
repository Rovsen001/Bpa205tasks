using Simulation4.Models;
using System.ComponentModel.DataAnnotations;

namespace Simulation4.Areas.Admin.ViewModels.Product
{
    public class CreateProductVM
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Max 30 characters"),
            MinLength(3, ErrorMessage = "Min 2 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "Max 100 characters"),
            MinLength(10, ErrorMessage = "Min 10 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
