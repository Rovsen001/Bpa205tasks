using HomeSimulation2.Areas.Admin.ViewModels.City;
using HomeSimulation2.DAL;
using HomeSimulation2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CityController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<City> cities = await _db.Cities.ToListAsync();
            return View(cities);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityVM createVM)
        {
            City city = new City()
            {
                Name = createVM.Name,
            };
            if (!ModelState.IsValid) return View(createVM);
            await _db.Cities.AddAsync(city);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            City city = await _db.Cities.FirstOrDefaultAsync(c => c.Id == id);
            UpdateCityVM updateVM = new UpdateCityVM()
            {
                Name = city.Name
            };
            return View(updateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCityVM updateVM)
        {
            if (!ModelState.IsValid) return View(updateVM);
            City city = await _db.Cities.FindAsync(updateVM.Id);
            city.Name = updateVM.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            City city = await _db.Cities.FindAsync(id);
            city.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            City city = await _db.Cities.FindAsync(id);
            city.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
