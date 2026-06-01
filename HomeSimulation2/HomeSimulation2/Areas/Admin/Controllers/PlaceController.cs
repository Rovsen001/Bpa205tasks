using HomeSimulation2.Areas.Admin.ViewModels.Place;
using HomeSimulation2.DAL;
using HomeSimulation2.Models;
using HomeSimulation2.Utilities.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PlaceController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Place> places = await _db.Places.Include(p => p.City).ToListAsync();
            return View(places);
        }
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Cities = await _db.Cities.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceVM createVM)
        {
            ViewBag.Cities = await _db.Cities.ToListAsync();
            if (createVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            if (!createVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            if (createVM.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            if (!ModelState.IsValid) return View(createVM);
            Place place = new Place()
            {
                Name = createVM.Name,
                FullAdress = createVM.FullAdress,
                CityId = createVM.CityId,
                ImageUrl = createVM.ImageFile.SaveImage(_env,"uploads/places")
            };
            await _db.Places.AddAsync(place);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Citys = await _db.Cities.ToListAsync();
            Place place = await _db.Places.FirstOrDefaultAsync(p => p.Id == id);
            UpdatePlaceVM updateVM = new UpdatePlaceVM()
            {
                Name = place.Name,
                FullAdress = place.FullAdress,
                CityId = place.CityId,
                ImageUrl = place.ImageUrl
            };
            return View(updateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePlaceVM updateVM)
        {
            ViewBag.Citys = await _db.Cities.ToListAsync();
            if (!ModelState.IsValid) return View(updateVM);
            Place place = await _db.Places.FindAsync(updateVM.Id);
            place.Name = updateVM.Name;
            place.FullAdress = updateVM.FullAdress;
            place.CityId = updateVM.CityId;
            place.ImageUrl = updateVM.ImageFile.SaveImage(_env, "uploads/places");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Place place = await _db.Places.FindAsync(id);
            place.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Place place = await _db.Places.FindAsync(id);
            place.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
