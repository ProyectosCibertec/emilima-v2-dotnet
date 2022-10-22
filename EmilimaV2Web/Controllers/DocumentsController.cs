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
    public class DocumentsController : Controller
    {
        private readonly EmilimaContext _context;

        public DocumentsController(EmilimaContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var emilimaContext = _context.Documents.Include(d => d.DocumentRequest).Include(d => d.DocumentSerie).Include(d => d.DocumentType).Include(d => d.File);
            return View(await emilimaContext.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.DocumentRequest)
                .Include(d => d.DocumentSerie)
                .Include(d => d.DocumentType)
                .Include(d => d.File)
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["DocumentRequestId"] = new SelectList(_context.DocumentRequests, "Id", "Id");
            ViewData["DocumentSerieId"] = new SelectList(_context.DocumentalSeries, "Code", "Code");
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "Id", "Id");
            ViewData["FileId"] = new SelectList(_context.Files, "Id", "Id");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,Name,Description,UploadDate,CreationDate,FileId,DocumentTypeId,DocumentSerieId,DocumentRequestId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentRequestId"] = new SelectList(_context.DocumentRequests, "Id", "Id", document.DocumentRequestId);
            ViewData["DocumentSerieId"] = new SelectList(_context.DocumentalSeries, "Code", "Code", document.DocumentSerieId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "Id", "Id", document.DocumentTypeId);
            ViewData["FileId"] = new SelectList(_context.Files, "Id", "Id", document.FileId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["DocumentRequestId"] = new SelectList(_context.DocumentRequests, "Id", "Id", document.DocumentRequestId);
            ViewData["DocumentSerieId"] = new SelectList(_context.DocumentalSeries, "Code", "Code", document.DocumentSerieId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "Id", "Id", document.DocumentTypeId);
            ViewData["FileId"] = new SelectList(_context.Files, "Id", "Id", document.FileId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialNumber,Name,Description,UploadDate,CreationDate,FileId,DocumentTypeId,DocumentSerieId,DocumentRequestId")] Document document)
        {
            if (id != document.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.SerialNumber))
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
            ViewData["DocumentRequestId"] = new SelectList(_context.DocumentRequests, "Id", "Id", document.DocumentRequestId);
            ViewData["DocumentSerieId"] = new SelectList(_context.DocumentalSeries, "Code", "Code", document.DocumentSerieId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "Id", "Id", document.DocumentTypeId);
            ViewData["FileId"] = new SelectList(_context.Files, "Id", "Id", document.FileId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.DocumentRequest)
                .Include(d => d.DocumentSerie)
                .Include(d => d.DocumentType)
                .Include(d => d.File)
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'emilimaContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
          return _context.Documents.Any(e => e.SerialNumber == id);
        }
    }
}
