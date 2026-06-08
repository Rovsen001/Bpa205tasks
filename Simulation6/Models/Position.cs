using Simulation6.Models.Base;

namespace Simulation6.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
