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
    public class EstablecimientoesController : Controller
    {
        private readonly QuchoochContext _context;

        public EstablecimientoesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Establecimientoes
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var establecimientos = from establecimiento in _context.Establecimientos select establecimiento;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                establecimientos = establecimientos.Where(s => s.Nombre!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            switch (ordenActual)
            {
                case "NombreDescendente":
                    establecimientos = establecimientos.OrderByDescending(establecimiento => establecimiento.Nombre);
                    break;
                default:
                    establecimientos = establecimientos.OrderBy(establecimiento => establecimiento.Nombre);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<Establecimiento>.CrearPaginacion(establecimientos.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: Establecimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Establecimientos == null)
            {
                return NotFound();
            }

            var establecimiento = await _context.Establecimientos
                .FirstOrDefaultAsync(m => m.CodigoEstablecimiento == id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // GET: Establecimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Establecimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEstablecimiento,Nombre")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(establecimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: Establecimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Establecimientos == null)
            {
                return NotFound();
            }

            var establecimiento = await _context.Establecimientos.FindAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEstablecimiento,Nombre")] Establecimiento establecimiento)
        {
            if (id != establecimiento.CodigoEstablecimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(establecimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstablecimientoExists(establecimiento.CodigoEstablecimiento))
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
            return View(establecimiento);
        }

        // GET: Establecimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Establecimientos == null)
            {
                return NotFound();
            }

            var establecimiento = await _context.Establecimientos
                .FirstOrDefaultAsync(m => m.CodigoEstablecimiento == id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // POST: Establecimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Establecimientos == null)
            {
                return Problem("Entity set 'QuchoochContext.Establecimientos'  is null.");
            }
            var establecimiento = await _context.Establecimientos.FindAsync(id);
            if (establecimiento != null)
            {
                _context.Establecimientos.Remove(establecimiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstablecimientoExists(int id)
        {
          return (_context.Establecimientos?.Any(e => e.CodigoEstablecimiento == id)).GetValueOrDefault();
        }
    }
}
