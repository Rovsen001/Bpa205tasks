using Azure;
using BPA205Pronia.Models.Base;
using static System.Net.Mime.MediaTypeNames;

namespace LiquarShopDataTask.Models
{
    public class Product : BaseEntity
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
    }
}
