using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation123.Areas.Admin.ViewModels.Product;
using Simulation123.DAL;
using Simulation123.Models;
using Simulation123.Utilities.Image;

namespace Simulation123.Areas.Admin.Controllers
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
            List<Product> products = await _db.Products
                .Include(p => p.Category)
                .ToListAsync();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            if (createProductVM.ImageFile != null) {
                ModelState.AddModelError("ImageFile","File not found");
                return View(createProductVM);
            }
            if (!createProductVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File type not matched ");
                return View(createProductVM);
            }
            if(createProductVM.ImageFile.Length> 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "File size must be max 2MB");
                return View(createProductVM);
            }
            Product product =new Product()
            {
                Category = createProductVM.Category,
                Name= createProductVM.Name,
                Price = createProductVM.Price,
                Description = createProductVM.Description,
                GameId= createProductVM.GameId
            };
            if(!ModelState.IsValid)return View(product);
            product.ImageUrl = createProductVM.ImageFile.SaveImage(_env,"uploads/product");
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _db.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id==id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(p => p.Id == updateProductVM.Id);
            product.Name = updateProductVM.Name;
            product.Price = updateProductVM.Price;
            product.Description = updateProductVM.Description;
            product.Category= updateProductVM.Category;
            product.ImageUrl = updateProductVM.ImageFile.SaveImage(_env, "upload/product");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
