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
    public class DocumentRequestsController : Controller
    {
        private readonly EmilimaContext _context;

        public DocumentRequestsController(EmilimaContext context)
        {
            _context = context;
        }

        // GET: DocumentRequests
        public async Task<IActionResult> Index()
        {
            var emilimaContext = _context.DocumentRequests.Include(d => d.OrganicUnit).Include(d => d.State).Include(d => d.User);
            return View(await emilimaContext.ToListAsync());
        }

        // GET: DocumentRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentRequests == null)
            {
                return NotFound();
            }

            var documentRequest = await _context.DocumentRequests
                .Include(d => d.OrganicUnit)
                .Include(d => d.State)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentRequest == null)
            {
                return NotFound();
            }

            return View(documentRequest);
        }

        // GET: DocumentRequests/Create
        public IActionResult Create()
        {
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id");
            ViewData["StateId"] = new SelectList(_context.RequestStates, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users1, "Username", "Username");
            return View();
        }

        // POST: DocumentRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreationDate,StateId,UserId,OrganicUnitId")] DocumentRequest documentRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentRequest.OrganicUnitId);
            ViewData["StateId"] = new SelectList(_context.RequestStates, "Id", "Id", documentRequest.StateId);
            ViewData["UserId"] = new SelectList(_context.Users1, "Username", "Username", documentRequest.UserId);
            return View(documentRequest);
        }

        // GET: DocumentRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentRequests == null)
            {
                return NotFound();
            }

            var documentRequest = await _context.DocumentRequests.FindAsync(id);
            if (documentRequest == null)
            {
                return NotFound();
            }
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentRequest.OrganicUnitId);
            ViewData["StateId"] = new SelectList(_context.RequestStates, "Id", "Id", documentRequest.StateId);
            ViewData["UserId"] = new SelectList(_context.Users1, "Username", "Username", documentRequest.UserId);
            return View(documentRequest);
        }

        // POST: DocumentRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreationDate,StateId,UserId,OrganicUnitId")] DocumentRequest documentRequest)
        {
            if (id != documentRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentRequestExists(documentRequest.Id))
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
            ViewData["OrganicUnitId"] = new SelectList(_context.OrganicUnits, "Id", "Id", documentRequest.OrganicUnitId);
            ViewData["StateId"] = new SelectList(_context.RequestStates, "Id", "Id", documentRequest.StateId);
            ViewData["UserId"] = new SelectList(_context.Users1, "Username", "Username", documentRequest.UserId);
            return View(documentRequest);
        }

        // GET: DocumentRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentRequests == null)
            {
                return NotFound();
            }

            var documentRequest = await _context.DocumentRequests
                .Include(d => d.OrganicUnit)
                .Include(d => d.State)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentRequest == null)
            {
                return NotFound();
            }

            return View(documentRequest);
        }

        // POST: DocumentRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentRequests == null)
            {
                return Problem("Entity set 'emilimaContext.DocumentRequests'  is null.");
            }
            var documentRequest = await _context.DocumentRequests.FindAsync(id);
            if (documentRequest != null)
            {
                _context.DocumentRequests.Remove(documentRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentRequestExists(int id)
        {
          return _context.DocumentRequests.Any(e => e.Id == id);
        }
    }
}
