using Simulation2.Models.Base;

namespace Simulation2.Models
{
    public class Crypto : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
