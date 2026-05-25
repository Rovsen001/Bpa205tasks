using DigiMediaTask.DAL;
using DigiMediaTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace DigiMediaTask.Controllers
{

    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Project> projects = _db.Projects
                .ToList();
            return View(projects);
        }
    }
}
