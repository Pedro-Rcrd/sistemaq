using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class ComunidadsController : Controller
    {
        private readonly QuchoochContext _context;

        public ComunidadsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Comunidads
        public async Task<IActionResult> Index()
        {
              return _context.Comunidads != null ? 
                          View(await _context.Comunidads.ToListAsync()) :
                          Problem("Entity set 'QuchoochContext.Comunidads'  is null.");
        }

        // GET: Comunidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comunidads == null)
            {
                return NotFound();
            }

            var comunidad = await _context.Comunidads
                .FirstOrDefaultAsync(m => m.CodigoComunidad == id);
            if (comunidad == null)
            {
                return NotFound();
            }

            return View(comunidad);
        }

        // GET: Comunidads/Create
        public IActionResult Create()
        {
            return View();
        }

	  // GET: Generar PDF
        public async Task<IActionResult> ImprimirComunidad()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirComunidad", await _context.Comunidads.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Comunidades.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }
	

        // POST: Comunidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoComunidad,NombreComunidad")] Comunidad comunidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comunidad);
        }

        // GET: Comunidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comunidads == null)
            {
                return NotFound();
            }

            var comunidad = await _context.Comunidads.FindAsync(id);
            if (comunidad == null)
            {
                return NotFound();
            }
            return View(comunidad);
        }

        // POST: Comunidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoComunidad,NombreComunidad")] Comunidad comunidad)
        {
            if (id != comunidad.CodigoComunidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadExists(comunidad.CodigoComunidad))
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
            return View(comunidad);
        }

        // GET: Comunidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comunidads == null)
            {
                return NotFound();
            }

            var comunidad = await _context.Comunidads
                .FirstOrDefaultAsync(m => m.CodigoComunidad == id);
            if (comunidad == null)
            {
                return NotFound();
            }

            return View(comunidad);
        }

        // POST: Comunidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comunidads == null)
            {
                return Problem("Entity set 'QuchoochContext.Comunidads'  is null.");
            }
            var comunidad = await _context.Comunidads.FindAsync(id);
            if (comunidad != null)
            {
                _context.Comunidads.Remove(comunidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadExists(int id)
        {
          return (_context.Comunidads?.Any(e => e.CodigoComunidad == id)).GetValueOrDefault();
        }
    }
}
