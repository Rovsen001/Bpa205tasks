using HomeSimulation4.Models.Base;

namespace HomeSimulation4.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
