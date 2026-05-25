using ProniaCRUDTask.Models;
using ProniaCRUDTask.Models.Base;

namespace ProniaCRUDTask.ViewModels.Product
{
    public class ProductVM : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string ImageUrl{ get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
        public List<int> ReviewIds { get; set; }
    }
}
