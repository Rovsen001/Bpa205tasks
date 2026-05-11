using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ProniaCRUDTask.Areas.Admin.ViewModels.Product;
using ProniaCRUDTask.DAL;
using ProniaCRUDTask.Models;

namespace ProniaCRUDTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products=await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            Product product = new Product() { 
                Name = productVM.Name,
                Price = productVM.Price,
                Description = productVM.Description,
                SKU = productVM.SKU
            };

            if (productVM.CategoryIds!=null)
            {
                product.Categories=await _db.Categories.Where(c => productVM.CategoryIds.Contains(c.Id)).ToListAsync();
            }
            if (productVM.TagIds != null)
            {
                product.Tags = await _db.Tags.Where(t => productVM.TagIds.Contains(t.Id)).ToListAsync();
            }
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           Product product=await _db.Products.FindAsync(id);
            product.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            Product product = await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id==id);
            UpdateProductVM productVM = new UpdateProductVM() {
                 Id = product.Id,
                 Name = product.Name,
                 Price = product.Price,
                 Description = product.Description,
                 CategoryIds = product.Categories.Select(c => c.Id).ToList(),
                 TagIds = product.Tags.Select(t => t.Id).ToList()

            };
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            Product product = await _db.Products
             .Include(p => p.Categories)
             .Include(p => p.Tags)
             .FirstOrDefaultAsync(p => p.Id == productVM.Id);
            product.Id = productVM.Id;
            product.Name = productVM.Name;
            product.Description = productVM.Description;
            product.Price = productVM.Price;
            product.Categories.Clear();
            if (productVM.CategoryIds != null)
            {
                product.Categories = await _db.Categories.Where(c => productVM.CategoryIds.Contains(c.Id)).ToListAsync();
            }
            product.Tags.Clear();
            if (productVM.TagIds is not null)
            {
                product.Tags = await _db.Tags.Where(t => productVM.TagIds.Contains(t.Id)).ToListAsync();
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
