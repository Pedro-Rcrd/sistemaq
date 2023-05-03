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
    public class EstablecimientoesController : Controller
    {
        private readonly QuchoochContext _context;

        public EstablecimientoesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Establecimientoes
        public async Task<IActionResult> Index()
        {
              return _context.Establecimientos != null ? 
                          View(await _context.Establecimientos.ToListAsync()) :
                          Problem("Entity set 'QuchoochContext.Establecimientos'  is null.");
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



	public async Task<IActionResult> ImprimirEstablecimiento()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirEstablecimiento", await _context.Establecimientos.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Establecimientos.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

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
