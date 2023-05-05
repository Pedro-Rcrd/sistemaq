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
    public class TutoriumsController : Controller
    {
        private readonly QuchoochContext _context;

        public TutoriumsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Tutoriums
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var tutors = from tutor in _context.Tutors select tutor;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                tutors = tutors.Where(s => s.CodigoTutor!.Equals(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroCodigoEstudiante"] = String.IsNullOrEmpty(ordenActual) ? "CodigoEstudianteDescendente" : "";
            ViewData["FiltroCodigoEstudiante"] = ordenActual == "CodigoEstudiante" ? "CodigoEstudianteDescendente" : "CodigoEstudianteAscendente";

            switch (ordenActual)
            {
                case "CodigoEstudianteDescendente":
                    tutors = tutors.OrderByDescending(tutor => tutor.CodigoTutor);
                    break;
                default:
                    tutors = tutors.OrderBy(tutor => tutor.CodigoTutor);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<Tutorium>.CrearPaginacion(tutors.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: Tutoriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tutoria == null)
            {
                return NotFound();
            }

            var tutorium = await _context.Tutoria
                .Include(t => t.CodigoAreaNavigation)
                .Include(t => t.CodigoCursoNavigation)
                .Include(t => t.CodigoTutorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutoria == id);
            if (tutorium == null)
            {
                return NotFound();
            }

            return View(tutorium);
        }

        // GET: Tutoriums/Create
        public IActionResult Create()
        {
            ViewData["CodigoArea"] = new SelectList(_context.Areas, "CodigoArea", "CodigoArea");
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso");
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "CodigoTutor");
            return View();
        }

        // POST: Tutoriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTutoria,CodigoCurso,CodigoArea,CodigoTutor,FechaCreacion,HoraInicio,HoraFinal,Tema")] Tutorium tutorium)
        {
            if (ModelState != null)
            {
                _context.Add(tutorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoArea"] = new SelectList(_context.Areas, "CodigoArea", "CodigoArea", tutorium.CodigoArea);
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", tutorium.CodigoCurso);
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "CodigoTutor", tutorium.CodigoTutor);
            return View(tutorium);
        }

        // GET: Tutoriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tutoria == null)
            {
                return NotFound();
            }

            var tutorium = await _context.Tutoria.FindAsync(id);
            if (tutorium == null)
            {
                return NotFound();
            }
            ViewData["CodigoArea"] = new SelectList(_context.Areas, "CodigoArea", "CodigoArea", tutorium.CodigoArea);
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", tutorium.CodigoCurso);
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "CodigoTutor", tutorium.CodigoTutor);
            return View(tutorium);
        }

        // POST: Tutoriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTutoria,CodigoCurso,CodigoArea,CodigoTutor,FechaCreacion,HoraInicio,HoraFinal,Tema")] Tutorium tutorium)
        {
            if (id != tutorium.CodigoTutoria)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(tutorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutoriumExists(tutorium.CodigoTutoria))
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
            ViewData["CodigoArea"] = new SelectList(_context.Areas, "CodigoArea", "CodigoArea", tutorium.CodigoArea);
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", tutorium.CodigoCurso);
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "CodigoTutor", tutorium.CodigoTutor);
            return View(tutorium);
        }

        // GET: Tutoriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tutoria == null)
            {
                return NotFound();
            }

            var tutorium = await _context.Tutoria
                .Include(t => t.CodigoAreaNavigation)
                .Include(t => t.CodigoCursoNavigation)
                .Include(t => t.CodigoTutorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutoria == id);
            if (tutorium == null)
            {
                return NotFound();
            }

            return View(tutorium);
        }

        // POST: Tutoriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tutoria == null)
            {
                return Problem("Entity set 'QuchoochContext.Tutoria'  is null.");
            }
            var tutorium = await _context.Tutoria.FindAsync(id);
            if (tutorium != null)
            {
                _context.Tutoria.Remove(tutorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutoriumExists(int id)
        {
          return (_context.Tutoria?.Any(e => e.CodigoTutoria == id)).GetValueOrDefault();
        }
    }
}
