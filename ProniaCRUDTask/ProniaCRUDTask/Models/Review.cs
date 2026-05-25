using ProniaCRUDTask.Models.Base;

namespace ProniaCRUDTask.Models
{
    public class Review : BaseEntity
    {
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}
