using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmilimaV2Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmilimaV2Web.Controllers
{
    [Authorize]
    public class UserPositionsController : Controller
    {
        private readonly EmilimaContext _context;

        public UserPositionsController(EmilimaContext context)
        {
            _context = context;
        }

        // GET: UserPositions
        public async Task<IActionResult> Index()
        {
            var emilimaContext = _context.UserPositions.Include(u => u.HierarchicalDependency).Include(u => u.OrganicUnit);
            return View(await emilimaContext.ToListAsync());
        }

        // GET: UserPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserPositions == null)
            {
                return NotFound();
            }

            var userPosition = await _context.UserPositions
                .Include(u => u.HierarchicalDependency)
                .Include(u => u.OrganicUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPosition == null)
            {
                return NotFound();
            }

            return View(userPosition);
        }

        // GET: UserPositions/Create
        public IActionResult Create()
        {
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id");
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id");
            return View();
        }

        // POST: UserPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OrganicUnitId,HierarchicalDependencyId")] UserPosition userPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", userPosition.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", userPosition.OrganicUnitId);
            return View(userPosition);
        }

        // GET: UserPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserPositions == null)
            {
                return NotFound();
            }

            var userPosition = await _context.UserPositions.FindAsync(id);
            if (userPosition == null)
            {
                return NotFound();
            }
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", userPosition.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", userPosition.OrganicUnitId);
            return View(userPosition);
        }

        // POST: UserPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OrganicUnitId,HierarchicalDependencyId")] UserPosition userPosition)
        {
            if (id != userPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPositionExists(userPosition.Id))
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
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", userPosition.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", userPosition.OrganicUnitId);
            return View(userPosition);
        }

        // GET: UserPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserPositions == null)
            {
                return NotFound();
            }

            var userPosition = await _context.UserPositions
                .Include(u => u.HierarchicalDependency)
                .Include(u => u.OrganicUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPosition == null)
            {
                return NotFound();
            }

            return View(userPosition);
        }

        // POST: UserPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserPositions == null)
            {
                return Problem("Entity set 'emilimaContext.UserPositions'  is null.");
            }
            var userPosition = await _context.UserPositions.FindAsync(id);
            if (userPosition != null)
            {
                _context.UserPositions.Remove(userPosition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPositionExists(int id)
        {
          return _context.UserPositions.Any(e => e.Id == id);
        }
    }
}
