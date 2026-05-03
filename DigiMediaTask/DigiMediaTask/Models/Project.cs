using DigiMediaTask.Models.Base;

namespace DigiMediaTask.Models
{
    public class Project : BaseEntity
    {
        public string Profession { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
