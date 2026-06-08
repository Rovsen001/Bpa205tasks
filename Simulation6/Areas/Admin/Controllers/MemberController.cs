using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation6.Areas.Admin.ViewModels.Member;
using Simulation6.DAL;
using Simulation6.Models;
using Simulation6.Utilities.Image;

namespace Simulation6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public MemberController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members= await _db.Members.Include(m=>m.Position).ToListAsync();
            return View(members);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Positions=await _db.Positions.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberVM memberVM)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            if (!ModelState.IsValid) return View(memberVM);
            if (!memberVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile","File must be an image");
            }
            if (memberVM.ImageFile==null)
            {
                ModelState.AddModelError("ImageFile", "File required");
            }
            if (memberVM.ImageFile.Length>2*1024*1024)
            {
                ModelState.AddModelError("ImageFile", "File size exceed 2 MB");
            }
            Member member = new Member()
            {
                Name = memberVM.Name,
                Surname = memberVM.Surname,
                Description = memberVM.Description,
                PositionId = memberVM.PositionId,
                ImageUrl=memberVM.ImageFile.SaveImage(_env,"uploads/members")
            };
            await _db.Members.AddAsync(member);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            Member member = await _db.Members.FirstOrDefaultAsync(m => m.Id == id);
            if (member == null) return View();
            UpdateMemberVM memberVM = new UpdateMemberVM()
            {
                Name= member.Name,
                Surname= member.Surname,
                Description= member.Description,
                PositionId= member.PositionId,
                ImageUrl= member.ImageUrl
            };
            return View(memberVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMemberVM memberVM)
        {
            ViewBag.Positions = await _db.Positions.ToListAsync();
            if (!ModelState.IsValid) return View(memberVM);
            if (!memberVM.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be an image");
            }
            if (memberVM.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "File required");
            }
            if (memberVM.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "File size exceed 2 MB");
            }
            Member member = await _db.Members.Include(m=>m.Position).FirstOrDefaultAsync(m=>m.Id == memberVM.Id);
            member.Name= memberVM.Name;
            member.Surname= memberVM.Surname;
            member.Description= memberVM.Description;
            member.PositionId= memberVM.PositionId;
            member.ImageUrl = memberVM.ImageFile.SaveImage(_env, "uploads/members");
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Member member=await _db.Members.FindAsync(id);
            member.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Member member = await _db.Members.FindAsync(id);
            member.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
