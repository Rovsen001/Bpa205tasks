using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simulation6.Models;
using Simulation6.ViewModels.Account;

namespace Simulation6.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Register", "Register Failed");
                return View(registerVM);
            }
            if (registerVM == null)
            {
                ModelState.AddModelError("Register", "Register Failed");
                return View(registerVM);
            }
            AppUser user = new AppUser()
            {
                UserName = registerVM.Username,
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
            };
            IdentityResult result= await _userManager.CreateAsync(user,registerVM.Password);
            await _userManager.AddToRoleAsync(user,"User");
            if (result.Succeeded)
            {
                ModelState.AddModelError("Register","Register Failed");
                return View(registerVM);
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Login", "Login Failed");
                return View(loginVM);
            }
            if (loginVM == null)
            {
                ModelState.AddModelError("Login", "Login Failed");
                return View(loginVM);
            }
            AppUser user = await _userManager.FindByEmailAsync(loginVM.Email);
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("Login", "LoginFailed");
                return View(loginVM);
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Create()
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            return Content("Created");
        }
    }
}
