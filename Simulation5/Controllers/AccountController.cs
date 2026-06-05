using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation5.Models;
using Simulation5.ViewModels.Account;

namespace Simulation5.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM regsiterVM)
        {
            AppUser user = new AppUser()
            {
                Name = regsiterVM.Name,
                UserName = regsiterVM.UserName,
                Surname= regsiterVM.Surname,
                Email = regsiterVM.Email,
            };
            IdentityResult result=await _userManager.CreateAsync(user,regsiterVM.Password);
            if (!result.Succeeded)
            {
                return View(regsiterVM);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser user=await _userManager.FindByEmailAsync(loginVM.Email);

            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            return Content("Created");
        }
    }
}
