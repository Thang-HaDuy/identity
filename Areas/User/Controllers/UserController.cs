using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using identity.Areas.User.Models;
using identity.Data;
using identity.Areas.User.Services.UserService;
using identity.Areas.User.Dtos.User;
using identity.Areas.User.Services;
// using X.PagedList;

namespace identity.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        // GET: User/User
        // public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Index(string CurrentFilter, string SearchString, int? Page)
        // {
        //     var response = await _userService.IndexAsync(CurrentFilter, SearchString, Page);
        //     ViewBag.CurrentFilter = CurrentFilter;
        //     if (response.Null != true)
        //     {
        //         return View(response.Data);
        //     }
        //     else
        //     {
        //         return Problem("Entity set 'Database.User' is null.");
        //     }
        // }

        public Task<IActionResult> Index(string CurrentFilter, string SearchString, int? Page)
        {
            var response = await _userService.IndexAsync(CurrentFilter, SearchString, Page);
            ViewBag.CurrentFilter = CurrentFilter;
            if (response.Null != true)
            {
                return View(response.Data);
            }
            else
            {
                return Problem("Entity set 'Database.User' is null.");
            }
        }

        // GET: User/User/Details/5
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Details(string id)
        {
            var response = await _userService.DetailAsync(id);
            if (response.Success == false)
            {
                return NotFound();
            }
            else
            {
                return View(response.Data);
            }
        }

        // // GET: User/User/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // // POST: User/User/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("CreateAt,UpdatedAt,DeletedAt,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AppUser appUser)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(appUser);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(appUser);
        // }

        // // GET: User/User/Edit/5
        // public async Task<IActionResult> Edit(string id)
        // {
        //     if (id == null || _context.Users == null)
        //     {
        //         return NotFound();
        //     }

        //     var appUser = await _context.Users.FindAsync(id);
        //     if (appUser == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(appUser);
        // }

        // // POST: User/User/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(string id, [Bind("CreateAt,UpdatedAt,DeletedAt,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AppUser appUser)
        // {
        //     if (id != appUser.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(appUser);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!AppUserExists(appUser.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(appUser);
        // }

        // // GET: User/User/Delete/5
        // public async Task<IActionResult> Delete(string id)
        // {
        //     if (id == null || _context.Users == null)
        //     {
        //         return NotFound();
        //     }

        //     var appUser = await _context.Users
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (appUser == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(appUser);
        // }

        // // POST: User/User/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(string id)
        // {
        //     if (_context.Users == null)
        //     {
        //         return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        //     }
        //     var appUser = await _context.Users.FindAsync(id);
        //     if (appUser != null)
        //     {
        //         _context.Users.Remove(appUser);
        //     }
            
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool AppUserExists(string id)
        // {
        //   return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
