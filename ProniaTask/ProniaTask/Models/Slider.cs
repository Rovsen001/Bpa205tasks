using ProniaTask.Models.Base;

namespace ProniaTask.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public List<Image> ImageUrl { get; set; }
    }
}
