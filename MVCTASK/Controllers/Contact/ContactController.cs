using Microsoft.AspNetCore.Mvc;

namespace MVCTASK.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
