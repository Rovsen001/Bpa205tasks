using Microsoft.AspNetCore.Mvc;
using Simulation2.Areas.Admin.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using Simulation2.DAL;
using Simulation2.Models;

namespace Simulation2.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty,"Error");
                return View(categoryVM);
            }
            Category category = new Category()
            {
                Name = categoryVM.Name
            };
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            UpdateCategoryVM categoryVM = new UpdateCategoryVM()
            {
                Name = category.Name
            };
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM categoryVM)
        {
            Category oldcategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == categoryVM.Id);
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
