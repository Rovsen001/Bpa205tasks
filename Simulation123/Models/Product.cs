using Simulation123.Models.Base;

namespace Simulation123.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string GameId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
