using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation2.DAL;
using Simulation2.Models;

namespace Simulation2.Controllers
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
            List<Crypto> cryptos = await _db.Cryptos.Include(c => c.Category).ToListAsync();
            return View(cryptos);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            Crypto crypto = await _db.Cryptos.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id==id);
            return View(crypto);
        }
    }
}
