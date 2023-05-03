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
    public class GastoesController : Controller
    {
        private readonly QuchoochContext _context;

        public GastoesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Gastoes
        public async Task<IActionResult> Index()
        {
            var quchoochContext = _context.Gastos.Include(g => g.CodigoEstudianteNavigation);
            return View(await quchoochContext.ToListAsync());
        }

        // GET: Gastoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gastos == null)
            {
                return NotFound();
            }

            var gasto = await _context.Gastos
                .Include(g => g.CodigoEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGasto == id);
            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        // GET: Gastoes/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            return View();
        }


	 // GET: Generar PDF
        public async Task<IActionResult> ImprimirGastoes()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirGastoes", await _context.Gastos.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Gastos.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }

        // POST: Gastoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoGasto,CodigoEstudiante,TipoPago,FechaEntrega,NumeroDocumento,Monto,Descripcion")] Gasto gasto)
        {
            if (ModelState != null)
            {
                _context.Add(gasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", gasto.CodigoEstudiante);
            return View(gasto);
        }

        // GET: Gastoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gastos == null)
            {
                return NotFound();
            }

            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", gasto.CodigoEstudiante);
            return View(gasto);
        }

        // POST: Gastoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoGasto,CodigoEstudiante,TipoPago,FechaEntrega,NumeroDocumento,Monto,Descripcion")] Gasto gasto)
        {
            if (id != gasto.CodigoGasto)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(gasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GastoExists(gasto.CodigoGasto))
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", gasto.CodigoEstudiante);
            return View(gasto);
        }

        // GET: Gastoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gastos == null)
            {
                return NotFound();
            }

            var gasto = await _context.Gastos
                .Include(g => g.CodigoEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.CodigoGasto == id);
            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        // POST: Gastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gastos == null)
            {
                return Problem("Entity set 'QuchoochContext.Gastos'  is null.");
            }
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GastoExists(int id)
        {
          return (_context.Gastos?.Any(e => e.CodigoGasto == id)).GetValueOrDefault();
        }
    }
}
