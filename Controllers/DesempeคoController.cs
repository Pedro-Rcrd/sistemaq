using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using systemquchooch.Models;
using systemquchooch.Data;

namespace systemquchooch.Controllers
{
    public class DesempeñoController : Controller
    {
        private readonly QuchoochContext _context;

        public DesempeñoController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Desempeño
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var desempeños = from desempeño in _context.Desempeños select desempeño;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                desempeños = desempeños.Where(s => s.Nombre!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            desempeños = ordenActual switch
            {
                "NombreDescendente" => desempeños.OrderByDescending(desempeño => desempeño.Nombre),
                _ => desempeños.OrderBy(desempeño => desempeño.Nombre),
            };
            int cantidadregistros = 10;

            return View(await Paginacion<Desempeño>.CrearPaginacion(desempeños.AsNoTracking(), numpag ?? 1, cantidadregistros));
        }

        // GET: Desempeño/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desempeños == null)
            {
                return NotFound();
            }

            var desempeño = await _context.Desempeños
                .FirstOrDefaultAsync(m => m.CodigoDesempeño == id);
            if (desempeño == null)
            {
                return NotFound();
            }

            return View(desempeño);
        }

        // GET: Desempeño/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Generar PDF
        public async Task<IActionResult> ImprimirDesempeño()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirDesempeño", await _context.Desempeños.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Desempeño.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }



        // POST: Desempeño/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDesempeño,Nombre")] Desempeño desempeño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desempeño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desempeño);
        }

        // GET: Desempeño/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desempeños == null)
            {
                return NotFound();
            }

            var desempeño = await _context.Desempeños.FindAsync(id);
            if (desempeño == null)
            {
                return NotFound();
            }
            return View(desempeño);
        }

        // POST: Desempeño/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDesempeño,Nombre")] Desempeño desempeño)
        {
            if (id != desempeño.CodigoDesempeño)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desempeño);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesempeñoExists(desempeño.CodigoDesempeño))
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
            return View(desempeño);
        }

        // GET: Desempeño/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desempeños == null)
            {
                return NotFound();
            }

            var desempeño = await _context.Desempeños
                .FirstOrDefaultAsync(m => m.CodigoDesempeño == id);
            if (desempeño == null)
            {
                return NotFound();
            }

            return View(desempeño);
        }

        // POST: Desempeño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desempeños == null)
            {
                return Problem("Entity set 'QuchoochContext.Desempeños'  is null.");
            }
            var desempeño = await _context.Desempeños.FindAsync(id);
            if (desempeño != null)
            {
                _context.Desempeños.Remove(desempeño);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesempeñoExists(int id)
        {
            return (_context.Desempeños?.Any(e => e.CodigoDesempeño == id)).GetValueOrDefault();
        }
    }
}
