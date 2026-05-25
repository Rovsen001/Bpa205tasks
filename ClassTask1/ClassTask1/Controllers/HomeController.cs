using ClassTask1.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ClassTask1.Controllers
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
            return View();
        }
    }
}
