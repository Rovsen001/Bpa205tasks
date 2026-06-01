using HomeSimulation.DAL;
using HomeSimulation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation.Controllers
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
            List<Employee> employees= await _db.Employees
                .Include(e => e.Position)
                .ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> Details(int? id)
        {
            Employee? employee=await _db.Employees
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.Id == id);
            return View(employee);
        }
    }
}
