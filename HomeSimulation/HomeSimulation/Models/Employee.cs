using HomeSimulation.Models.Base;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace HomeSimulation.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public string ImageUrl { get; set; }
    }
}
