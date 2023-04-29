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
    public class GradoesController : Controller
    {
        private readonly QuchoochContext _context;

        public GradoesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Gradoes
        public async Task<IActionResult> Index()
        {
              return _context.Grados != null ? 
                          View(await _context.Grados.ToListAsync()) :
                          Problem("Entity set 'QuchoochContext.Grados'  is null.");
        }

        // GET: Gradoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grados == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados
                .FirstOrDefaultAsync(m => m.CodigoGrado == id);
            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        // GET: Gradoes/Create
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> ImprimirGrado()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirGrado", await _context.Grados.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Grado.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }
        // POST: Gradoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoGrado,Nombre")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grado);
        }

        // GET: Gradoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grados == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }
            return View(grado);
        }

        // POST: Gradoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoGrado,Nombre")] Grado grado)
        {
            if (id != grado.CodigoGrado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradoExists(grado.CodigoGrado))
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
            return View(grado);
        }

        // GET: Gradoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grados == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados
                .FirstOrDefaultAsync(m => m.CodigoGrado == id);
            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        // POST: Gradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grados == null)
            {
                return Problem("Entity set 'QuchoochContext.Grados'  is null.");
            }
            var grado = await _context.Grados.FindAsync(id);
            if (grado != null)
            {
                _context.Grados.Remove(grado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradoExists(int id)
        {
          return (_context.Grados?.Any(e => e.CodigoGrado == id)).GetValueOrDefault();
        }
    }
}
