using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using Microsoft.EntityFrameworkCore;

using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class TutorsController : Controller
    {
        private readonly QuchoochContext _context;

        public TutorsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Tutors
        public async Task<IActionResult> Index()
        {
            var quchoochContext = _context.Tutors.Include(t => t.CodigoProfesionNavigation);
            return View(await quchoochContext.ToListAsync());
        }

        // GET: Tutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors
                .Include(t => t.CodigoProfesionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutor == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            ViewData["CodigoProfesion"] = new SelectList(_context.Profesions, "CodigoProfesion", "CodigoProfesion");
            return View();
        }


        // GET: Generar PDF
        public async Task<IActionResult> ImprimirTutor()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirTutor", await _context.Tutors.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Tutor.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }



        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTutor,CodigoProfesion,Nombre,Apellido,Telefono,Email,FechaCreacion")] Tutor tutor)
        {
            if (ModelState != null)
            {
                _context.Add(tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoProfesion"] = new SelectList(_context.Profesions, "CodigoProfesion", "CodigoProfesion", tutor.CodigoProfesion);
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            ViewData["CodigoProfesion"] = new SelectList(_context.Profesions, "CodigoProfesion", "CodigoProfesion", tutor.CodigoProfesion);
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTutor,CodigoProfesion,Nombre,Apellido,Telefono,Email,FechaCreacion")] Tutor tutor)
        {
            if (id != tutor.CodigoTutor)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(tutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorExists(tutor.CodigoTutor))
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
            ViewData["CodigoProfesion"] = new SelectList(_context.Profesions, "CodigoProfesion", "CodigoProfesion", tutor.CodigoProfesion);
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors
                .Include(t => t.CodigoProfesionNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTutor == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tutors == null)
            {
                return Problem("Entity set 'QuchoochContext.Tutors'  is null.");
            }
            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor != null)
            {
                _context.Tutors.Remove(tutor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorExists(int id)
        {
          return (_context.Tutors?.Any(e => e.CodigoTutor == id)).GetValueOrDefault();
        }
    }
}
