using System.ComponentModel.DataAnnotations;

namespace HomeSimulation4.Areas.Admin.ViewModels.Position
{
    public class UpdatePositionVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage = "Name must contains max 30 characters"),
            MinLength(3, ErrorMessage = "Name must contains min 3 characters")]
        public string Name { get; set; }
    }
}
