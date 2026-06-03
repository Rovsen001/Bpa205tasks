using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation4.Areas.Admin.ViewModels.Category;
using Simulation4.Areas.Admin.ViewModels.Category;
using Simulation4.DAL;
using Simulation4.Models;

namespace Simulation4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _db.Categories.ToListAsync();
            return View(categories);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM categoryVM)
        {
            Category category = new Category()
            {
                Name = categoryVM.Name
            };
            if (!ModelState.IsValid) return View(categoryVM);
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("id", "Not found");
                return View(null);
            }
            Category category = await _db.Categories.FirstOrDefaultAsync(p => p.Id == id);
            UpdateCategoryVM categoryVM = new UpdateCategoryVM()
            {
                Name = category.Name
            };
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View(categoryVM);
            Category oldcategory = await _db.Categories.FirstOrDefaultAsync(p => p.Id == categoryVM.Id);
            oldcategory.Name = categoryVM.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Category category = await _db.Categories.FindAsync(id);
            category.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Category category = await _db.Categories.FindAsync(id);
            category.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
