using Microsoft.AspNetCore.Mvc;

namespace ProniaCRUDTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
