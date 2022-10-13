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
    public class HierarchicalDependenciesController : Controller
    {
        private readonly emilimaContext _context;

        public HierarchicalDependenciesController(emilimaContext context)
        {
            _context = context;
        }

        // GET: HierarchicalDependencies
        public async Task<IActionResult> Index()
        {
              return View(await _context.HierarchicalDependencies.ToListAsync());
        }

        // GET: HierarchicalDependencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HierarchicalDependencies == null)
            {
                return NotFound();
            }

            var hierarchicalDependency = await _context.HierarchicalDependencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hierarchicalDependency == null)
            {
                return NotFound();
            }

            return View(hierarchicalDependency);
        }

        // GET: HierarchicalDependencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HierarchicalDependencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] HierarchicalDependency hierarchicalDependency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hierarchicalDependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hierarchicalDependency);
        }

        // GET: HierarchicalDependencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HierarchicalDependencies == null)
            {
                return NotFound();
            }

            var hierarchicalDependency = await _context.HierarchicalDependencies.FindAsync(id);
            if (hierarchicalDependency == null)
            {
                return NotFound();
            }
            return View(hierarchicalDependency);
        }

        // POST: HierarchicalDependencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] HierarchicalDependency hierarchicalDependency)
        {
            if (id != hierarchicalDependency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hierarchicalDependency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HierarchicalDependencyExists(hierarchicalDependency.Id))
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
            return View(hierarchicalDependency);
        }

        // GET: HierarchicalDependencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HierarchicalDependencies == null)
            {
                return NotFound();
            }

            var hierarchicalDependency = await _context.HierarchicalDependencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hierarchicalDependency == null)
            {
                return NotFound();
            }

            return View(hierarchicalDependency);
        }

        // POST: HierarchicalDependencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HierarchicalDependencies == null)
            {
                return Problem("Entity set 'emilimaContext.HierarchicalDependencies'  is null.");
            }
            var hierarchicalDependency = await _context.HierarchicalDependencies.FindAsync(id);
            if (hierarchicalDependency != null)
            {
                _context.HierarchicalDependencies.Remove(hierarchicalDependency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HierarchicalDependencyExists(int id)
        {
          return _context.HierarchicalDependencies.Any(e => e.Id == id);
        }
    }
}
