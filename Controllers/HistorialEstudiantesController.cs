using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class HistorialEstudiantesController : Controller
    {
        private readonly QuchoochContext _context;

        public HistorialEstudiantesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: HistorialEstudiantes
        public async Task<IActionResult> Index()
        {
            var quchoochContext = _context.HistorialEstudiantes.Include(h => h.CodigoCarreraNavigation).Include(h => h.CodigoEstablecimientoNavigation).Include(h => h.CodigoEstudianteNavigation).Include(h => h.CodigoGradoNavigation).Include(h => h.CodigoNivelAcademicoNavigation);
            return View(await quchoochContext.ToListAsync());
        }

        // GET: HistorialEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistorialEstudiantes == null)
            {
                return NotFound();
            }

            var historialEstudiante = await _context.HistorialEstudiantes
                .Include(h => h.CodigoCarreraNavigation)
                .Include(h => h.CodigoEstablecimientoNavigation)
                .Include(h => h.CodigoEstudianteNavigation)
                .Include(h => h.CodigoGradoNavigation)
                .Include(h => h.CodigoNivelAcademicoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHistorialEstudiante == id);
            if (historialEstudiante == null)
            {
                return NotFound();
            }

            return View(historialEstudiante);
        }

        // GET: HistorialEstudiantes/Create
        public IActionResult Create()
        {
            ViewData["CodigoCarrera"] = new SelectList(_context.Carreras, "CodigoCarrera", "CodigoCarrera");
            ViewData["CodigoEstablecimiento"] = new SelectList(_context.Establecimientos, "CodigoEstablecimiento", "CodigoEstablecimiento");
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["CodigoGrado"] = new SelectList(_context.Grados, "CodigoGrado", "CodigoGrado");
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico");
            return View();
        }

        // POST: HistorialEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoHistorialEstudiante,CodigoEstudiante,CodigoNivelAcademico,CodigoGrado,CodigoCarrera,CodigoEstablecimiento,FechaCreacion")] HistorialEstudiante historialEstudiante)
        {
            if (ModelState != null)
            {
                _context.Add(historialEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoCarrera"] = new SelectList(_context.Carreras, "CodigoCarrera", "CodigoCarrera", historialEstudiante.CodigoCarrera);
            ViewData["CodigoEstablecimiento"] = new SelectList(_context.Establecimientos, "CodigoEstablecimiento", "CodigoEstablecimiento", historialEstudiante.CodigoEstablecimiento);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", historialEstudiante.CodigoEstudiante);
            ViewData["CodigoGrado"] = new SelectList(_context.Grados, "CodigoGrado", "CodigoGrado", historialEstudiante.CodigoGrado);
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", historialEstudiante.CodigoNivelAcademico);
            return View(historialEstudiante);
        }

        // GET: HistorialEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistorialEstudiantes == null)
            {
                return NotFound();
            }

            var historialEstudiante = await _context.HistorialEstudiantes.FindAsync(id);
            if (historialEstudiante == null)
            {
                return NotFound();
            }
            ViewData["CodigoCarrera"] = new SelectList(_context.Carreras, "CodigoCarrera", "CodigoCarrera", historialEstudiante.CodigoCarrera);
            ViewData["CodigoEstablecimiento"] = new SelectList(_context.Establecimientos, "CodigoEstablecimiento", "CodigoEstablecimiento", historialEstudiante.CodigoEstablecimiento);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", historialEstudiante.CodigoEstudiante);
            ViewData["CodigoGrado"] = new SelectList(_context.Grados, "CodigoGrado", "CodigoGrado", historialEstudiante.CodigoGrado);
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", historialEstudiante.CodigoNivelAcademico);
            return View(historialEstudiante);
        }

        // POST: HistorialEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoHistorialEstudiante,CodigoEstudiante,CodigoNivelAcademico,CodigoGrado,CodigoCarrera,CodigoEstablecimiento,FechaCreacion")] HistorialEstudiante historialEstudiante)
        {
            if (id != historialEstudiante.CodigoHistorialEstudiante)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(historialEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialEstudianteExists(historialEstudiante.CodigoHistorialEstudiante))
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
            ViewData["CodigoCarrera"] = new SelectList(_context.Carreras, "CodigoCarrera", "CodigoCarrera", historialEstudiante.CodigoCarrera);
            ViewData["CodigoEstablecimiento"] = new SelectList(_context.Establecimientos, "CodigoEstablecimiento", "CodigoEstablecimiento", historialEstudiante.CodigoEstablecimiento);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", historialEstudiante.CodigoEstudiante);
            ViewData["CodigoGrado"] = new SelectList(_context.Grados, "CodigoGrado", "CodigoGrado", historialEstudiante.CodigoGrado);
            ViewData["CodigoNivelAcademico"] = new SelectList(_context.NivelAcademicos, "CodigoNivelAcademico", "CodigoNivelAcademico", historialEstudiante.CodigoNivelAcademico);
            return View(historialEstudiante);
        }

        // GET: HistorialEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistorialEstudiantes == null)
            {
                return NotFound();
            }

            var historialEstudiante = await _context.HistorialEstudiantes
                .Include(h => h.CodigoCarreraNavigation)
                .Include(h => h.CodigoEstablecimientoNavigation)
                .Include(h => h.CodigoEstudianteNavigation)
                .Include(h => h.CodigoGradoNavigation)
                .Include(h => h.CodigoNivelAcademicoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHistorialEstudiante == id);
            if (historialEstudiante == null)
            {
                return NotFound();
            }

            return View(historialEstudiante);
        }

        // POST: HistorialEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistorialEstudiantes == null)
            {
                return Problem("Entity set 'QuchoochContext.HistorialEstudiantes'  is null.");
            }
            var historialEstudiante = await _context.HistorialEstudiantes.FindAsync(id);
            if (historialEstudiante != null)
            {
                _context.HistorialEstudiantes.Remove(historialEstudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialEstudianteExists(int id)
        {
          return (_context.HistorialEstudiantes?.Any(e => e.CodigoHistorialEstudiante == id)).GetValueOrDefault();
        }
    }
}
