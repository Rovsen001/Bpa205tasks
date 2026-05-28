using HomeSimulation2.Models.Base;

namespace HomeSimulation2.Models
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public string FullAdress { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string ImageUrl { get; set; }
    }
}
