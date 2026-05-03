using DigiMediaTask.DAL;
using DigiMediaTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMediaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _db;
        public ProjectController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Project> Projects = _db.Projects.ToList();
            return View(Projects);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project Project)
        {
            _db.Projects.Add(Project);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Project Project = _db.Projects.Find(id);
            Project.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Restore(int id)
        {
            Project Project = _db.Projects.Find(id);
            Project.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}