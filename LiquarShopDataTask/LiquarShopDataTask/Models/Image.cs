using BPA205Pronia.Models.Base;

namespace LiquarShopDataTask.Models
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Product Product { get; set; }
    }
}
