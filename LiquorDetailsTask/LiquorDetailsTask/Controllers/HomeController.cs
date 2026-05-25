using LiquorDetailsTask.DAL;
using LiquorDetailsTask.Models;
using LiquorDetailsTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiquorDetailsTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            List<Product> products = _db.Products
                .Include(p => p.Images)
                .ToList();

            HomeVM vM = new HomeVM()
            {
                Products = products,
                Sliders = sliders
            };

            return View(vM);
        }
        public IActionResult Details(int id)
        {
            Product singleProduct = _db.Products
                 .Include(p => p.Images)
                 .FirstOrDefault(p => p.Id == id);
            return View(singleProduct);
        }
    }
}
