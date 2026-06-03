using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation4.Areas.Admin.ViewModels.Product;
using Simulation4.DAL;
using Simulation4.Models;
using Simulation4.Utilities.image;

namespace Simulation4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            List<Product> products =await _db.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories=await _db.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (productVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image cannot be empty");
                return View(productVM);
            }
            if (!productVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File type not match");
                return View(productVM);
            }
            if (productVM.ImageFile.Length>2*1024*1024)
            {
                ModelState.AddModelError("ImageFile", "File must be max 2MB");
                return View(productVM);
            }
            Product product = new Product()
            {
                Name= productVM.Name,
                Price= productVM.Price,
                Description= productVM.Description,
                CategoryId= productVM.CategoryId
            };
            product.ImageUrl = productVM.ImageFile.SaveImage(_env, "uploads/products");
            if (!ModelState.IsValid) return View(productVM);
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (id == null)
            {
                ModelState.AddModelError("id", "Not found");
                return View(null);
            }
            Product product = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            UpdateProductVM productVM = new UpdateProductVM()
            {
                Name=product.Name,
                Price= product.Price,
                Description=product.Description,
                CategoryId = product.CategoryId,
                ImageUrl= product.ImageUrl
            };
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (productVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image cannot be empty");
                return View(productVM);
            }
            if (!productVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File type not match");
                return View(productVM);
            }
            if (productVM.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "File must be max 2MB");
                return View(productVM);
            }
            if (!ModelState.IsValid) return View(productVM);
            Product oldproduct=await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id==productVM.Id);
            oldproduct.Name=productVM.Name;
            oldproduct.Price=productVM.Price;
            oldproduct.Description=productVM.Description;
            oldproduct.CategoryId=productVM.CategoryId;
            oldproduct.ImageUrl = productVM.ImageFile.SaveImage(_env, "upload/products");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
