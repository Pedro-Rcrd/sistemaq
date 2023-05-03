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
    public class PaisController : Controller
    {
        private readonly QuchoochContext _context;

        public PaisController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Pais
        public async Task<IActionResult> Index()
        {
              return _context.Pais != null ? 
                          View(await _context.Pais.ToListAsync()) :
                          Problem("Entity set 'QuchoochContext.Pais'  is null.");
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pais == null)
            {
                return NotFound();
            }

            var pai = await _context.Pais
                .FirstOrDefaultAsync(m => m.CodigoPais == id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }


	// GET: Generar PDF
        public async Task<IActionResult> ImprimirPais()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirPais", await _context.Pais.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Pais.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }


        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPais,Nombre")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pai);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pais == null)
            {
                return NotFound();
            }

            var pai = await _context.Pais.FindAsync(id);
            if (pai == null)
            {
                return NotFound();
            }
            return View(pai);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPais,Nombre")] Pai pai)
        {
            if (id != pai.CodigoPais)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiExists(pai.CodigoPais))
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
            return View(pai);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pais == null)
            {
                return NotFound();
            }

            var pai = await _context.Pais
                .FirstOrDefaultAsync(m => m.CodigoPais == id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pais == null)
            {
                return Problem("Entity set 'QuchoochContext.Pais'  is null.");
            }
            var pai = await _context.Pais.FindAsync(id);
            if (pai != null)
            {
                _context.Pais.Remove(pai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiExists(int id)
        {
          return (_context.Pais?.Any(e => e.CodigoPais == id)).GetValueOrDefault();
        }
    }
}
