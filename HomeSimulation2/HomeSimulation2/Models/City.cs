using HomeSimulation2.Models.Base;

namespace HomeSimulation2.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public List<Place> Places { get; set; }
    }
}
