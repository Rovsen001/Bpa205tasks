namespace ProniaCRUDTask.Areas.Admin.ViewModels.Product
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
    }
}
