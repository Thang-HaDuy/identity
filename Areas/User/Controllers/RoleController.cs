using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using identity.Areas.User.Models;
using identity.Data;

namespace identity.Areas.User.Controllers
{
    [Area("User")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Role
        public async Task<IActionResult> Index()
        {
              return _context.Roles != null ? 
                          View(await _context.Roles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Roles'  is null.");
        }

        // GET: User/Role/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // GET: User/Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

        // GET: User/Role/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _context.Roles.FindAsync(id);
            if (appRole == null)
            {
                return NotFound();
            }
            return View(appRole);
        }

        // POST: User/Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppRole appRole)
        {
            if (id != appRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppRoleExists(appRole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

        // GET: User/Role/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // POST: User/Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Roles'  is null.");
            }
            var appRole = await _context.Roles.FindAsync(id);
            if (appRole != null)
            {
                _context.Roles.Remove(appRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppRoleExists(string id)
        {
          return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
