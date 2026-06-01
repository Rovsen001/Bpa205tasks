using HomeSimulation3.Models.Base;

namespace HomeSimulation3.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
