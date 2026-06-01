using HomeSimulation2.DAL;
using HomeSimulation2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation2.Controllers
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
            List<Place> places = await _db.Places
                .Include(p => p.City)
                .ToListAsync();
            return View(places);
        }
        public async Task<IActionResult> Details(int? id)
        {
            Place? place = await _db.Places
                .Include(p => p.City)
                .FirstOrDefaultAsync(p => p.Id == id);
            return View(place);
        }
    }
}
