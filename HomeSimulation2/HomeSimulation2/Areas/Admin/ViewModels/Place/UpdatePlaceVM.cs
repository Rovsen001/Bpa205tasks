namespace HomeSimulation2.Areas.Admin.ViewModels.Place
{
    public class UpdatePlaceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullAdress { get; set; }
        public int CityId { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
