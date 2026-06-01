using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation2.Areas.Admin.ViewModels.Crypto;
using Simulation2.DAL;
using Simulation2.Models;
using Simulation2.Utilities.Image;

namespace Simulation2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CryptoController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CryptoController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env=env;
        }
        public async Task<IActionResult> Index()
        {
            List<Crypto> cryptos = await _db.Cryptos.Include(c => c.Category).ToListAsync();
            return View(cryptos);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories=await _db.Categories.ToListAsync();
            return View();
        }   
        [HttpPost]
        public async Task<IActionResult> Create(CreateCryptoVM cryptoVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (cryptoVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile","Image file cannot be empty");
                return View(cryptoVM);
            }
            if (!cryptoVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File type doesn't match");
                return View(cryptoVM);
            }
            if (cryptoVM.ImageFile.Length > 2*1024*1024)
            {
                ModelState.AddModelError("ImageFile", "File size max 2MB");
                return View(cryptoVM);
            }
            Crypto crypto = new Crypto()
            {
                Name = cryptoVM.Name,
                Price = cryptoVM.Price,
                Description = cryptoVM.Description,
                CategoryId=cryptoVM.CategoryId
            };
            crypto.ImageUrl = cryptoVM.ImageFile.SaveImage(_env,"uploads/cryptos");
            await _db.Cryptos.AddAsync(crypto);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            Crypto crypto = await _db.Cryptos.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id==id);
            UpdateCryptoVM cryptoVM = new UpdateCryptoVM()
            {
                Name=crypto.Name,
                Price= crypto.Price,
                Description= crypto.Description,
                CategoryId= crypto.CategoryId,
                ImageUrl=crypto.ImageUrl
            };
            return View(cryptoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCryptoVM cryptoVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            Crypto oldcrypto = await _db.Cryptos.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id==cryptoVM.Id);
            oldcrypto.Name = cryptoVM.Name;
            oldcrypto.Price = cryptoVM.Price;
            oldcrypto.Description = cryptoVM.Description;
            oldcrypto.Category = await _db.Categories.FindAsync(cryptoVM.CategoryId);
            oldcrypto.ImageUrl= cryptoVM.ImageFile.SaveImage(_env,"uploads/cryptos");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Crypto crypto = await _db.Cryptos.FindAsync(id);
            crypto.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Crypto crypto = await _db.Cryptos.FindAsync(id);
            crypto.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
