using HomeSimulation.Areas.Admin.ViewModels.Position;
using HomeSimulation.DAL;
using HomeSimulation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PositionController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Position> positions = await _db.Postions.ToListAsync();
            return View(positions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionVM createVM)
        {
            Position position = new Position()
            {
                Name = createVM.Name,
            };
            if (!ModelState.IsValid) return View(createVM);
            await _db.Postions.AddAsync(position);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            Position position = await _db.Postions.FirstOrDefaultAsync(e => e.Id == id);
            UpdatePositionVM updateVM = new UpdatePositionVM()
            {
                Name = position.Name
            };
            return View(updateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePositionVM updateVM)
        {
            if (!ModelState.IsValid) return View(updateVM);
            Position position = await _db.Postions.FindAsync(updateVM.Id);
            position.Name = updateVM.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Position position = await _db.Postions.FindAsync(id);
            position.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Position position = await _db.Postions.FindAsync(id);
            position.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
