using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmilimaV2Web.Models;

namespace EmilimaV2Web.Controllers
{
    public class User1Controller : Controller
    {
        private readonly emilimaContext _context;

        public User1Controller(emilimaContext context)
        {
            _context = context;
        }

        // GET: User1
        public async Task<IActionResult> Index()
        {
            var emilimaContext = _context.Users1.Include(u => u.Photo).Include(u => u.Position).Include(u => u.Role);
            return View(await emilimaContext.ToListAsync());
        }

        // GET: User1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Users1 == null)
            {
                return NotFound();
            }

            var user1 = await _context.Users1
                .Include(u => u.Photo)
                .Include(u => u.Position)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // GET: User1/Create
        public IActionResult Create()
        {
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id");
            ViewData["PositionId"] = new SelectList(_context.UserPositions, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "Id", "Id");
            return View();
        }

        // POST: User1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Email,RoleId,PhotoId,PositionId")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", user1.PhotoId);
            ViewData["PositionId"] = new SelectList(_context.UserPositions, "Id", "Id", user1.PositionId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "Id", "Id", user1.RoleId);
            return View(user1);
        }

        // GET: User1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Users1 == null)
            {
                return NotFound();
            }

            var user1 = await _context.Users1.FindAsync(id);
            if (user1 == null)
            {
                return NotFound();
            }
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", user1.PhotoId);
            ViewData["PositionId"] = new SelectList(_context.UserPositions, "Id", "Id", user1.PositionId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "Id", "Id", user1.RoleId);
            return View(user1);
        }

        // POST: User1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,Email,RoleId,PhotoId,PositionId")] User1 user1)
        {
            if (id != user1.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User1Exists(user1.Username))
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
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", user1.PhotoId);
            ViewData["PositionId"] = new SelectList(_context.UserPositions, "Id", "Id", user1.PositionId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "Id", "Id", user1.RoleId);
            return View(user1);
        }

        // GET: User1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Users1 == null)
            {
                return NotFound();
            }

            var user1 = await _context.Users1
                .Include(u => u.Photo)
                .Include(u => u.Position)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // POST: User1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users1 == null)
            {
                return Problem("Entity set 'emilimaContext.Users1'  is null.");
            }
            var user1 = await _context.Users1.FindAsync(id);
            if (user1 != null)
            {
                _context.Users1.Remove(user1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User1Exists(string id)
        {
          return _context.Users1.Any(e => e.Username == id);
        }
    }
}
