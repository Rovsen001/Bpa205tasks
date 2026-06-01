using Simulation2.Models.Base;

namespace Simulation2.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Crypto> Cryptos { get; set; }
    }
}
