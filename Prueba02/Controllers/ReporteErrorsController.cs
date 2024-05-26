using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba02.Models.dbModels;

namespace Prueba02.Controllers
{
    public class ReporteErrorsController : Controller
    {
        private readonly ProyectoContext _context;

        public ReporteErrorsController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: ReporteErrors
        public async Task<IActionResult> Index()
        {
              return _context.ReporteErrors != null ? 
                          View(await _context.ReporteErrors.ToListAsync()) :
                          Problem("Entity set 'ProyectoContext.ReporteErrors'  is null.");
        }

        // GET: ReporteErrors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReporteErrors == null)
            {
                return NotFound();
            }

            var reporteError = await _context.ReporteErrors
                .FirstOrDefaultAsync(m => m.IdReporteError == id);
            if (reporteError == null)
            {
                return NotFound();
            }

            return View(reporteError);
        }

        // GET: ReporteErrors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReporteErrors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReporteError,Nombre,CorreoElectronico,Descripcion,PasosParaReproducirError,UrlPaginaError,FechaError")] ReporteError reporteError)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteError);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporteError);
        }

        // GET: ReporteErrors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReporteErrors == null)
            {
                return NotFound();
            }

            var reporteError = await _context.ReporteErrors.FindAsync(id);
            if (reporteError == null)
            {
                return NotFound();
            }
            return View(reporteError);
        }

        // POST: ReporteErrors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReporteError,Nombre,CorreoElectronico,Descripcion,PasosParaReproducirError,UrlPaginaError,FechaError")] ReporteError reporteError)
        {
            if (id != reporteError.IdReporteError)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteError);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteErrorExists(reporteError.IdReporteError))
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
            return View(reporteError);
        }

        // GET: ReporteErrors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReporteErrors == null)
            {
                return NotFound();
            }

            var reporteError = await _context.ReporteErrors
                .FirstOrDefaultAsync(m => m.IdReporteError == id);
            if (reporteError == null)
            {
                return NotFound();
            }

            return View(reporteError);
        }

        // POST: ReporteErrors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReporteErrors == null)
            {
                return Problem("Entity set 'ProyectoContext.ReporteErrors'  is null.");
            }
            var reporteError = await _context.ReporteErrors.FindAsync(id);
            if (reporteError != null)
            {
                _context.ReporteErrors.Remove(reporteError);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteErrorExists(int id)
        {
          return (_context.ReporteErrors?.Any(e => e.IdReporteError == id)).GetValueOrDefault();
        }
    }
}
