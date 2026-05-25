using LiquorShopTask.Models;
using LiquorShopTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LiquorShopTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new HomeVM
            {
                Products = new List<Product>
        {
            new Product { Name = "Bacardi 151", ImageUrl = "/assets/images/prod-1.jpg", Price = 49 , Sale=39 },
            new Product { Name = "Jim Beam", ImageUrl = "/assets/images/prod-2.jpg", Price = 60 , Sale=50 },
            new Product { Name = "Rum", ImageUrl = "/assets/images/prod-3.jpg", Price = 50 , Sale = 35 },
            new Product { Name = "Tequila Gold", ImageUrl = "/assets/images/prod-4.jpg", Price = 70 , Sale=55 },
            new Product { Name = "Black Label", ImageUrl = "/assets/images/prod-5.jpg", Price = 80 , Sale = 59 },
            new Product { Name = "Macallan", ImageUrl = "/assets/images/prod-6.jpg", Price = 120 , Sale = 100 },
            new Product { Name = "Old Monk", ImageUrl = "/assets/images/prod-7.jpg", Price = 55 , Sale = 40 },
            new Product { Name = "Jameson", ImageUrl = "/assets/images/prod-8.jpg", Price = 65 , Sale = 45 }
        },

                Sliders = new List<Slider>
        {
            new Slider { Title = "Enjoy Premium Taste", ImageUrl = "/assets/images/bg_1.jpg" }
        }
            };

            return View(vm);
        }
    }
}
