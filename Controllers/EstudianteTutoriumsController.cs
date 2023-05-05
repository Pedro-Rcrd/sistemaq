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
    public class EstudianteTutoriumsController : Controller
    {
        private readonly QuchoochContext _context;

        public EstudianteTutoriumsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: EstudianteTutoriums
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var estudiantetutorias = from estudiantetutoria in _context.EstudianteTutoria select estudiantetutoria;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                estudiantetutorias = estudiantetutorias.Where(s => s.CodigoEstudiante!.Equals(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroCodigoEstudiante"] = String.IsNullOrEmpty(ordenActual) ? "CodigoEstudianteDescendente" : "";
            ViewData["FiltroCodigoEstudiante"] = ordenActual == "CodigoEstudiante" ? "CodigoEstudianteDescendente" : "CodigoEstudianteAscendente";

            switch (ordenActual)
            {
                case "CodigoEstudianteDescendente":
                    estudiantetutorias = estudiantetutorias.OrderByDescending(estudiantetutoria => estudiantetutoria.CodigoEstudiante);
                    break;
                default:
                    estudiantetutorias = estudiantetutorias.OrderBy(estudiantetutoria => estudiantetutoria.CodigoEstudiante);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<EstudianteTutorium>.CrearPaginacion(estudiantetutorias.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: EstudianteTutoriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstudianteTutoria == null)
            {
                return NotFound();
            }

            var estudianteTutorium = await _context.EstudianteTutoria
                .Include(e => e.CodigoEstudianteNavigation)
                .Include(e => e.CodigoTutoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudianteTutoria == id);
            if (estudianteTutorium == null)
            {
                return NotFound();
            }

            return View(estudianteTutorium);
        }

        // GET: EstudianteTutoriums/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria");
            return View();
        }

        // POST: EstudianteTutoriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEstudianteTutoria,CodigoEstudiante,CodigoTutoria")] EstudianteTutorium estudianteTutorium)
        {
            if (ModelState != null)
            {
                _context.Add(estudianteTutorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudianteTutorium.CodigoEstudiante);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", estudianteTutorium.CodigoTutoria);
            return View(estudianteTutorium);
        }

        // GET: EstudianteTutoriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstudianteTutoria == null)
            {
                return NotFound();
            }

            var estudianteTutorium = await _context.EstudianteTutoria.FindAsync(id);
            if (estudianteTutorium == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudianteTutorium.CodigoEstudiante);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", estudianteTutorium.CodigoTutoria);
            return View(estudianteTutorium);
        }

        // POST: EstudianteTutoriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEstudianteTutoria,CodigoEstudiante,CodigoTutoria")] EstudianteTutorium estudianteTutorium)
        {
            if (id != estudianteTutorium.CodigoEstudianteTutoria)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(estudianteTutorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteTutoriumExists(estudianteTutorium.CodigoEstudianteTutoria))
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudianteTutorium.CodigoEstudiante);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", estudianteTutorium.CodigoTutoria);
            return View(estudianteTutorium);
        }

        // GET: EstudianteTutoriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstudianteTutoria == null)
            {
                return NotFound();
            }

            var estudianteTutorium = await _context.EstudianteTutoria
                .Include(e => e.CodigoEstudianteNavigation)
                .Include(e => e.CodigoTutoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudianteTutoria == id);
            if (estudianteTutorium == null)
            {
                return NotFound();
            }

            return View(estudianteTutorium);
        }

        // POST: EstudianteTutoriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstudianteTutoria == null)
            {
                return Problem("Entity set 'QuchoochContext.EstudianteTutoria'  is null.");
            }
            var estudianteTutorium = await _context.EstudianteTutoria.FindAsync(id);
            if (estudianteTutorium != null)
            {
                _context.EstudianteTutoria.Remove(estudianteTutorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteTutoriumExists(int id)
        {
          return (_context.EstudianteTutoria?.Any(e => e.CodigoEstudianteTutoria == id)).GetValueOrDefault();
        }
    }
}
