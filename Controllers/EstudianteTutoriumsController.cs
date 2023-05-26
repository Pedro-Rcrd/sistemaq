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
    public class EstudianteTutoriumsController : Controller
    {
        private readonly QuchoochContext _context;

        public EstudianteTutoriumsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: EstudianteTutoriums
        public async Task<IActionResult> Index()
        {
            var quchoochContext = _context.EstudianteTutoria.Include(e => e.CodigoEstudianteNavigation).Include(e => e.CodigoTutoriaNavigation);
            return View(await quchoochContext.ToListAsync());
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "Nombre");
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria");
            return View();
        }

        // GET: Generar PDF
        public async Task<IActionResult> ImprimirEstudiante_tutoria()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirEstudiante_tutoria", await _context.EstudianteTutoria.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Estudiante_tutoria.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "Nombre", estudianteTutorium.CodigoEstudiante);
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "Nombre", estudianteTutorium.CodigoEstudiante);
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "Nombre", estudianteTutorium.CodigoEstudiante);
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
