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
    public class PatrocinadorsController : Controller
    {
        private readonly QuchoochContext _context;

        public PatrocinadorsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Patrocinadors
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var patrocinadors = from patrocinador in _context.Patrocinadors select patrocinador;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                patrocinadors = patrocinadors.Where(s => s.Nombre!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            switch (ordenActual)
            {
                case "NombreDescendente":
                    patrocinadors = patrocinadors.OrderByDescending(patrocinador => patrocinador.Nombre);
                    break;
                default:
                    patrocinadors = patrocinadors.OrderBy(patrocinador => patrocinador.Nombre);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<Patrocinador>.CrearPaginacion(patrocinadors.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: Patrocinadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patrocinadors == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadors
                .Include(p => p.CodigoNivelAcademicoNavigation)
                .Include(p => p.CodigoPaisNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPatrocinador == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // GET: Patrocinadors/Create
        public IActionResult Create()
        {
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico");
            ViewData["CodigoPais"] = new SelectList(_context.Pais, "CodigoPais", "CodigoPais");
            return View();
        }

        // POST: Patrocinadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPatrocinador,CodigoPais,CodigoNivelAcademico,Nombre,Apellido,Estado,FotoPerfil,FechaNacimiento,FechaCreacion")] Patrocinador patrocinador)
        {
            if (ModelState != null)
            {
                _context.Add(patrocinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", patrocinador.CodigoNivelAcademico);
            ViewData["CodigoPais"] = new SelectList(_context.Pais, "CodigoPais", "CodigoPais", patrocinador.CodigoPais);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patrocinadors == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadors.FindAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", patrocinador.CodigoNivelAcademico);
            ViewData["CodigoPais"] = new SelectList(_context.Pais, "CodigoPais", "CodigoPais", patrocinador.CodigoPais);
            return View(patrocinador);
        }

        // POST: Patrocinadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPatrocinador,CodigoPais,CodigoNivelAcademico,Nombre,Apellido,Estado,FotoPerfil,FechaNacimiento,FechaCreacion")] Patrocinador patrocinador)
        {
            if (id != patrocinador.CodigoPatrocinador)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(patrocinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadorExists(patrocinador.CodigoPatrocinador))
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
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", patrocinador.CodigoNivelAcademico);
            ViewData["CodigoPais"] = new SelectList(_context.Pais, "CodigoPais", "CodigoPais", patrocinador.CodigoPais);
            return View(patrocinador);
        }

        // GET: Patrocinadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Patrocinadors == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadors
                .Include(p => p.CodigoNivelAcademicoNavigation)
                .Include(p => p.CodigoPaisNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPatrocinador == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // POST: Patrocinadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patrocinadors == null)
            {
                return Problem("Entity set 'QuchoochContext.Patrocinadors'  is null.");
            }
            var patrocinador = await _context.Patrocinadors.FindAsync(id);
            if (patrocinador != null)
            {
                _context.Patrocinadors.Remove(patrocinador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadorExists(int id)
        {
          return (_context.Patrocinadors?.Any(e => e.CodigoPatrocinador == id)).GetValueOrDefault();
        }
    }
}
