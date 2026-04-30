using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTask.DAL;
using ProniaTask.Models;
using ProniaTask.ViewModels;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
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
               
                .Include(p => p.Categories)
                .Include(p => p.Reviews)
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id==id);

            return View(singleProduct);
        }
    }
}
