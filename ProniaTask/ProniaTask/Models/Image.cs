using ProniaTask.Models.Base;

namespace ProniaTask.Models
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Product Product { get; set; }
        public List<Slider> Slider { get; set; }
    }
}
