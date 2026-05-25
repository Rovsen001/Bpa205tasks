using LiquorDetailsTask.Models.Base;
using static System.Net.Mime.MediaTypeNames;

namespace LiquorDetailsTask.Models
{
    public class Product : BaseEntity
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public List<Images> Images { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
        public string Description { get; set; }
        public float StarRate { get; set; }
        public int Rating { get; set; }
        public int Sold { get; set; }
        public int AvailablePiece { get; set; }
    }
}
