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
    public class DocumentalSeriesController : Controller
    {
        private readonly EmilimaContext _context;

        public DocumentalSeriesController(EmilimaContext context)
        {
            _context = context;
        }

        // GET: DocumentalSeries
        public async Task<IActionResult> Index()
        {
            var emilimaContext = _context.DocumentalSeries.Include(d => d.HierarchicalDependency).Include(d => d.OrganicUnit);
            return View(await emilimaContext.ToListAsync());
        }

        // GET: DocumentalSeries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DocumentalSeries == null)
            {
                return NotFound();
            }

            var documentalSerie = await _context.DocumentalSeries
                .Include(d => d.HierarchicalDependency)
                .Include(d => d.OrganicUnit)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (documentalSerie == null)
            {
                return NotFound();
            }

            return View(documentalSerie);
        }

        // GET: DocumentalSeries/Create
        public IActionResult Create()
        {
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id");
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id");
            return View();
        }

        // POST: DocumentalSeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,HierarchicalDependencyId,OrganicUnitId,Definition,ServiceFrequency,NormativeScope,IsPublic,PhisicalFeatures,DocumentalSerieValue,YearsInManagementArchive,YearsInCentralArchive,ElaborationDate")] DocumentalSerie documentalSerie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentalSerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", documentalSerie.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentalSerie.OrganicUnitId);
            return View(documentalSerie);
        }

        // GET: DocumentalSeries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DocumentalSeries == null)
            {
                return NotFound();
            }

            var documentalSerie = await _context.DocumentalSeries.FindAsync(id);
            if (documentalSerie == null)
            {
                return NotFound();
            }
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", documentalSerie.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentalSerie.OrganicUnitId);
            return View(documentalSerie);
        }

        // POST: DocumentalSeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Name,HierarchicalDependencyId,OrganicUnitId,Definition,ServiceFrequency,NormativeScope,IsPublic,PhisicalFeatures,DocumentalSerieValue,YearsInManagementArchive,YearsInCentralArchive,ElaborationDate")] DocumentalSerie documentalSerie)
        {
            if (id != documentalSerie.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentalSerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentalSerieExists(documentalSerie.Code))
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
            ViewData["HierarchicalDependencyId"] = new SelectList(_context.HierarchicalDependencies, "Id", "Id", documentalSerie.HierarchicalDependencyId);
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentalSerie.OrganicUnitId);
            return View(documentalSerie);
        }

        // GET: DocumentalSeries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DocumentalSeries == null)
            {
                return NotFound();
            }

            var documentalSerie = await _context.DocumentalSeries
                .Include(d => d.HierarchicalDependency)
                .Include(d => d.OrganicUnit)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (documentalSerie == null)
            {
                return NotFound();
            }

            return View(documentalSerie);
        }

        // POST: DocumentalSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DocumentalSeries == null)
            {
                return Problem("Entity set 'emilimaContext.DocumentalSeries'  is null.");
            }
            var documentalSerie = await _context.DocumentalSeries.FindAsync(id);
            if (documentalSerie != null)
            {
                _context.DocumentalSeries.Remove(documentalSerie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentalSerieExists(string id)
        {
          return _context.DocumentalSeries.Any(e => e.Code == id);
        }
    }
}
