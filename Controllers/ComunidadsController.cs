using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;
using systemquchooch.Data;

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
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var comunidads = from comunidad in _context.Comunidads select comunidad;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                comunidads = comunidads.Where(s => s.NombreComunidad!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombreComunidad"] = String.IsNullOrEmpty(ordenActual) ? "NombreComunidadDescendente" : "";

            switch (ordenActual)
            {
                case "NombreComunidadDescendente":
                    comunidads = comunidads.OrderByDescending(comunidad => comunidad.NombreComunidad);
                    break;
                default:
                    comunidads = comunidads.OrderBy(comunidad => comunidad.NombreComunidad);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<Comunidad>.CrearPaginacion(comunidads.AsNoTracking(), numpag ?? 1, cantidadregistros));



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
