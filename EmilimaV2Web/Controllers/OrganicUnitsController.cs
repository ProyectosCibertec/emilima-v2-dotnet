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
    public class OrganicUnitsController : Controller
    {
        private readonly EmilimaContext _context;

        public OrganicUnitsController(EmilimaContext context)
        {
            _context = context;
        }

        // GET: OrganicUnits
        public async Task<IActionResult> Index()
        {
              return View(await _context.OrganicUnits.ToListAsync());
        }

        // GET: OrganicUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrganicUnits == null)
            {
                return NotFound();
            }

            var organicUnit = await _context.OrganicUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organicUnit == null)
            {
                return NotFound();
            }

            return View(organicUnit);
        }

        // GET: OrganicUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganicUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OrganicUnit organicUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organicUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organicUnit);
        }

        // GET: OrganicUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrganicUnits == null)
            {
                return NotFound();
            }

            var organicUnit = await _context.OrganicUnits.FindAsync(id);
            if (organicUnit == null)
            {
                return NotFound();
            }
            return View(organicUnit);
        }

        // POST: OrganicUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OrganicUnit organicUnit)
        {
            if (id != organicUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organicUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganicUnitExists(organicUnit.Id))
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
            return View(organicUnit);
        }

        // GET: OrganicUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrganicUnits == null)
            {
                return NotFound();
            }

            var organicUnit = await _context.OrganicUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organicUnit == null)
            {
                return NotFound();
            }

            return View(organicUnit);
        }

        // POST: OrganicUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrganicUnits == null)
            {
                return Problem("Entity set 'emilimaContext.OrganicUnits'  is null.");
            }
            var organicUnit = await _context.OrganicUnits.FindAsync(id);
            if (organicUnit != null)
            {
                _context.OrganicUnits.Remove(organicUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganicUnitExists(int id)
        {
          return _context.OrganicUnits.Any(e => e.Id == id);
        }
    }
}
