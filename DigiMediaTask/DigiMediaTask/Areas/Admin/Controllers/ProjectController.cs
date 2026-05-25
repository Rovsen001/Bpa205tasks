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
        public IActionResult Update(int id)
        {
            Project project = _db.Projects.Find(id);
            return View(project);
        }
        [HttpPost]
        public IActionResult Update(Project project)
        {
            if(!ModelState.IsValid) return View();
            Project Project=_db.Projects.Find(project.Id);
            Project.Profession = project.Profession;
            Project.Category = project.Category;
            Project.ImageUrl = project.ImageUrl;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}