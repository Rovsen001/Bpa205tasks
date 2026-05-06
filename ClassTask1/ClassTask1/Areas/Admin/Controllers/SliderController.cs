using ClassTask1.DAL;
using ClassTask1.Extensions.Slider;
using ClassTask1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassTask1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db,IWebHostEnvironment env)
        {
            _db= db;
            _env= env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders=_db.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "File required...");
                return View();

            }
            if (!slider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile","Wrong file type added...");
                return View();
            }
            if (slider.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "File size reaches limit (2MB)...");
                return View();
            }
            slider.ImageUrl = slider.ImageFile.Save(_env, "uploads/sliders");
            if (!ModelState.IsValid)return View();
            _db.Sliders.Add(slider);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Slider slider = _db.Sliders.Find(id);
            slider.IsDeleted= true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Restore(int id)
        {
            Slider slider = _db.Sliders.Find(id);
            slider.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider oldSlider=_db.Sliders.Find(slider.Id);
            oldSlider.Title= slider.Title;
            oldSlider.Description= slider.Description;
            oldSlider.ImageUrl= slider.ImageUrl;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
