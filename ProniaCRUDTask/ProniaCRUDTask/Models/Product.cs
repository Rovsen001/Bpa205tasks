using ProniaCRUDTask.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaCRUDTask.Models
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Required...")]
        [
            StringLength(30, ErrorMessage = "Must contains maximum 30 characters..."),
            MinLength(2, ErrorMessage = "Must contains minimum 2 characters...")
        ]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required...")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Required...")]
        [
           StringLength(30, ErrorMessage = "Must contains maximum 30 characters..."),
           MinLength(2, ErrorMessage = "Must contains minimum 2 characters...")
        ]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required...")]
        [
           StringLength(30, ErrorMessage = "Must contains maximum 30 characters..."),
           MinLength(2, ErrorMessage = "Must contains minimum 2 characters...")
        ]
        public string SKU { get; set; }
        public string ImageUrl { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
