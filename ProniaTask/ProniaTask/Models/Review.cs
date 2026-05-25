using ProniaTask.Models.Base;

namespace ProniaTask.Models
{
    public class Review : BaseEntity
    {
        public string Username { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
    }
}
