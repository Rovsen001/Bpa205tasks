using AspNetCoreGeneratedDocument;
using HomeSimulation4.Areas.Admin.ViewModels.Employee;
using HomeSimulation4.DAL;
using HomeSimulation4.Models;
using HomeSimulation4.Utilities.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeSimulation4.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _db.Employees.Include(e => e.Position).ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM createVM)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            if (createVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            if (!createVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            if (createVM.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "Error");
                return View(createVM);
            }
            Employee employee = new Employee()
            {
                Name = createVM.Name,
                Description = createVM.Description,
                PositionId=createVM.PositionId
            };
            if (!ModelState.IsValid) return View(createVM);
            employee.ImageUrl = createVM.ImageFile.SaveImage(_env,"uploads/employees");
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            Employee employee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
            UpdateEmployeeVM updateVM = new UpdateEmployeeVM()
            {
                Name = employee.Name,
                Description = employee.Description,
                PositionId = employee.PositionId,
                ImageUrl= employee.ImageUrl
            };
            return View(updateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeVM updateVM)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            if (!ModelState.IsValid) return View(updateVM);
            Employee employee = await _db.Employees.FindAsync(updateVM.Id);
            employee.Name = updateVM.Name;
            employee.Description = updateVM.Description;
            employee.PositionId = updateVM.PositionId;
            employee.ImageUrl = updateVM.ImageFile.SaveImage(_env, "uploads/employees");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Employee employee=await _db.Employees.FindAsync(id);
            employee.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Employee employee = await _db.Employees.FindAsync(id);
            employee.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
