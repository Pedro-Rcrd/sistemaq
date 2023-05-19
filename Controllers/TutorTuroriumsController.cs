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
    public class TutorTuroriumsController : Controller
    {
        private readonly QuchoochContext _context;

        public TutorTuroriumsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: TutorTuroriums
        public async Task<IActionResult> Index()
        {
            var quchoochContext = _context.TutorTuroria.Include(t => t.CodigoTutorNavigation).Include(t => t.CodigoTutoriaNavigation);
            return View(await quchoochContext.ToListAsync());
        }

        // GET: TutorTuroriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TutorTuroria == null)
            {
                return NotFound();
            }

            var tutorTurorium = await _context.TutorTuroria
                .Include(t => t.CodigoTutorNavigation)
                .Include(t => t.CodigoTutoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutorTutoria == id);
            if (tutorTurorium == null)
            {
                return NotFound();
            }

            return View(tutorTurorium);
        }

        // GET: TutorTuroriums/Create
        public IActionResult Create()
        {
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "Nombre");
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria");
            return View();
        }

        // GET: Generar PDF
        public async Task<IActionResult> ImprimirTutor_tutoria()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirTutor_tutoria", await _context.TutorTuroria.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Tutor_tutoria.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }




        // POST: TutorTuroriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTutorTutoria,CodigoTutor,CodigoTutoria")] TutorTurorium tutorTurorium)
        {
            if (ModelState != null)
            {
                _context.Add(tutorTurorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "Nombre", tutorTurorium.CodigoTutor);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", tutorTurorium.CodigoTutoria);
            return View(tutorTurorium);
        }

        // GET: TutorTuroriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TutorTuroria == null)
            {
                return NotFound();
            }

            var tutorTurorium = await _context.TutorTuroria.FindAsync(id);
            if (tutorTurorium == null)
            {
                return NotFound();
            }
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "Nombre", tutorTurorium.CodigoTutor);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", tutorTurorium.CodigoTutoria);
            return View(tutorTurorium);
        }

        // POST: TutorTuroriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTutorTutoria,CodigoTutor,CodigoTutoria")] TutorTurorium tutorTurorium)
        {
            if (id != tutorTurorium.CodigoTutorTutoria)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(tutorTurorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorTuroriumExists(tutorTurorium.CodigoTutorTutoria))
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
            ViewData["CodigoTutor"] = new SelectList(_context.Tutors, "CodigoTutor", "Nombre", tutorTurorium.CodigoTutor);
            ViewData["CodigoTutoria"] = new SelectList(_context.Tutoria, "CodigoTutoria", "CodigoTutoria", tutorTurorium.CodigoTutoria);
            return View(tutorTurorium);
        }

        // GET: TutorTuroriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TutorTuroria == null)
            {
                return NotFound();
            }

            var tutorTurorium = await _context.TutorTuroria
                .Include(t => t.CodigoTutorNavigation)
                .Include(t => t.CodigoTutoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutorTutoria == id);
            if (tutorTurorium == null)
            {
                return NotFound();
            }

            return View(tutorTurorium);
        }

        // POST: TutorTuroriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TutorTuroria == null)
            {
                return Problem("Entity set 'QuchoochContext.TutorTuroria'  is null.");
            }
            var tutorTurorium = await _context.TutorTuroria.FindAsync(id);
            if (tutorTurorium != null)
            {
                _context.TutorTuroria.Remove(tutorTurorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorTuroriumExists(int id)
        {
          return (_context.TutorTuroria?.Any(e => e.CodigoTutorTutoria == id)).GetValueOrDefault();
        }
    }
}
