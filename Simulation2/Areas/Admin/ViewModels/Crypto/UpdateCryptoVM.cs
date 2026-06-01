using System.ComponentModel.DataAnnotations;

namespace Simulation2.Areas.Admin.ViewModels.Crypto
{
    public class UpdateCryptoVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Max 20 characters"),
            MinLength(3, ErrorMessage = "Min 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(80, ErrorMessage = "Max 80 characters"),
            MinLength(10, ErrorMessage = "Min 10 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
