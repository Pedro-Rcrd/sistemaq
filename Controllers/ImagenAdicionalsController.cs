using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using systemquchooch.Data;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class ImagenAdicionalsController : Controller
    {
        private readonly QuchoochContext _context;

        public ImagenAdicionalsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: ImagenAdicionals
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var variables = from variable in _context.ImagenAdicionals select variable;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                variables = variables.Where(s => s.Descripcion!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            variables = ordenActual switch
            {
                "NombreDescendente" => variables.OrderByDescending(grado => grado.Descripcion),
                _ => variables.OrderBy(grado => grado.Descripcion),
            };
            int cantidadregistros = 10;

            return View(await Paginacion<ImagenAdicional>.CrearPaginacion(variables.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: ImagenAdicionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImagenAdicionals == null)
            {
                return NotFound();
            }

            var imagenAdicional = await _context.ImagenAdicionals
                .Include(i => i.CodigoFichaCalificacionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoImagenAdicional == id);
            if (imagenAdicional == null)
            {
                return NotFound();
            }

            return View(imagenAdicional);
        }

        // GET: ImagenAdicionals/Create
        public IActionResult Create()
        {
            ViewData["CodigoFichaCalificacion"] = new SelectList(_context.FichaCalificacions, "CodigoFichaCalificacion", "CodigoFichaCalificacion");
            return View();
        }

        // POST: ImagenAdicionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoImagenAdicional,CodigoFichaCalificacion,ImgAdicional,Descripcion")] ImagenAdicional imagenAdicional)
        {
            if (ModelState != null)
            {
                _context.Add(imagenAdicional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoFichaCalificacion"] = new SelectList(_context.FichaCalificacions, "CodigoFichaCalificacion", "CodigoFichaCalificacion", imagenAdicional.CodigoFichaCalificacion);
            return View(imagenAdicional);
        }

        // GET: ImagenAdicionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImagenAdicionals == null)
            {
                return NotFound();
            }

            var imagenAdicional = await _context.ImagenAdicionals.FindAsync(id);
            if (imagenAdicional == null)
            {
                return NotFound();
            }
            ViewData["CodigoFichaCalificacion"] = new SelectList(_context.FichaCalificacions, "CodigoFichaCalificacion", "CodigoFichaCalificacion", imagenAdicional.CodigoFichaCalificacion);
            return View(imagenAdicional);
        }

        // POST: ImagenAdicionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoImagenAdicional,CodigoFichaCalificacion,ImgAdicional,Descripcion")] ImagenAdicional imagenAdicional)
        {
            if (id != imagenAdicional.CodigoImagenAdicional)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(imagenAdicional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagenAdicionalExists(imagenAdicional.CodigoImagenAdicional))
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
            ViewData["CodigoFichaCalificacion"] = new SelectList(_context.FichaCalificacions, "CodigoFichaCalificacion", "CodigoFichaCalificacion", imagenAdicional.CodigoFichaCalificacion);
            return View(imagenAdicional);
        }

        // GET: ImagenAdicionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImagenAdicionals == null)
            {
                return NotFound();
            }

            var imagenAdicional = await _context.ImagenAdicionals
                .Include(i => i.CodigoFichaCalificacionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoImagenAdicional == id);
            if (imagenAdicional == null)
            {
                return NotFound();
            }

            return View(imagenAdicional);
        }

        // POST: ImagenAdicionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImagenAdicionals == null)
            {
                return Problem("Entity set 'QuchoochContext.ImagenAdicionals'  is null.");
            }
            var imagenAdicional = await _context.ImagenAdicionals.FindAsync(id);
            if (imagenAdicional != null)
            {
                _context.ImagenAdicionals.Remove(imagenAdicional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagenAdicionalExists(int id)
        {
            return (_context.ImagenAdicionals?.Any(e => e.CodigoImagenAdicional == id)).GetValueOrDefault();
        }
    }
}
