using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ProniaCRUDTask.DAL;
using ProniaCRUDTask.Models;
using ProniaCRUDTask.ViewModels.Product;

namespace ProniaCRUDTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> product = await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .ToListAsync();
            return View(product);
        }
        public async Task<IActionResult> Details(int id)
        {
            Product product = _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Id == id);
            
            return View(product);
        }
    }
}
