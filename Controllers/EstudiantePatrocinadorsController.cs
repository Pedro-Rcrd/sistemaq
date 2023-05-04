﻿using System;
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
    public class EstudiantePatrocinadorsController : Controller
    {
        private readonly QuchoochContext _context;

        public EstudiantePatrocinadorsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: EstudiantePatrocinadors
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var estudiantePatrocinadors = from estudiantePatrocinador in _context.EstudiantePatrocinadors select estudiantePatrocinador;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;

            int cantidadregistros = 10;

            return View(await Paginacion<Estudiante>.CrearPaginacion(estudiantePatrocinadors.AsNoTracking(), numpag ?? 1, cantidadregistros));

            var quchoochContext = _context.EstudiantePatrocinadors.Include(e => e.CodigoEstudianteNavigation).Include(e => e.CodigoPatrocinadorNavigation);
            return View(await quchoochContext.ToListAsync());
        }

        // GET: EstudiantePatrocinadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstudiantePatrocinadors == null)
            {
                return NotFound();
            }

            var estudiantePatrocinador = await _context.EstudiantePatrocinadors
                .Include(e => e.CodigoEstudianteNavigation)
                .Include(e => e.CodigoPatrocinadorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiantePatrocinador == id);
            if (estudiantePatrocinador == null)
            {
                return NotFound();
            }

            return View(estudiantePatrocinador);
        }

        // GET: EstudiantePatrocinadors/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["CodigoPatrocinador"] = new SelectList(_context.Patrocinadors, "CodigoPatrocinador", "CodigoPatrocinador");
            return View();
        }

        // POST: EstudiantePatrocinadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEstudiantePatrocinador,CodigoEstudiante,CodigoPatrocinador")] EstudiantePatrocinador estudiantePatrocinador)
        {
            if (ModelState != null)
            {
                _context.Add(estudiantePatrocinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantePatrocinador.CodigoEstudiante);
            ViewData["CodigoPatrocinador"] = new SelectList(_context.Patrocinadors, "CodigoPatrocinador", "CodigoPatrocinador", estudiantePatrocinador.CodigoPatrocinador);
            return View(estudiantePatrocinador);
        }

        // GET: EstudiantePatrocinadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstudiantePatrocinadors == null)
            {
                return NotFound();
            }

            var estudiantePatrocinador = await _context.EstudiantePatrocinadors.FindAsync(id);
            if (estudiantePatrocinador == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantePatrocinador.CodigoEstudiante);
            ViewData["CodigoPatrocinador"] = new SelectList(_context.Patrocinadors, "CodigoPatrocinador", "CodigoPatrocinador", estudiantePatrocinador.CodigoPatrocinador);
            return View(estudiantePatrocinador);
        }

        // POST: EstudiantePatrocinadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEstudiantePatrocinador,CodigoEstudiante,CodigoPatrocinador")] EstudiantePatrocinador estudiantePatrocinador)
        {
            if (id != estudiantePatrocinador.CodigoEstudiantePatrocinador)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(estudiantePatrocinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantePatrocinadorExists(estudiantePatrocinador.CodigoEstudiantePatrocinador))
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantePatrocinador.CodigoEstudiante);
            ViewData["CodigoPatrocinador"] = new SelectList(_context.Patrocinadors, "CodigoPatrocinador", "CodigoPatrocinador", estudiantePatrocinador.CodigoPatrocinador);
            return View(estudiantePatrocinador);
        }

        // GET: EstudiantePatrocinadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstudiantePatrocinadors == null)
            {
                return NotFound();
            }

            var estudiantePatrocinador = await _context.EstudiantePatrocinadors
                .Include(e => e.CodigoEstudianteNavigation)
                .Include(e => e.CodigoPatrocinadorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiantePatrocinador == id);
            if (estudiantePatrocinador == null)
            {
                return NotFound();
            }

            return View(estudiantePatrocinador);
        }

        // POST: EstudiantePatrocinadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstudiantePatrocinadors == null)
            {
                return Problem("Entity set 'QuchoochContext.EstudiantePatrocinadors'  is null.");
            }
            var estudiantePatrocinador = await _context.EstudiantePatrocinadors.FindAsync(id);
            if (estudiantePatrocinador != null)
            {
                _context.EstudiantePatrocinadors.Remove(estudiantePatrocinador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantePatrocinadorExists(int id)
        {
          return (_context.EstudiantePatrocinadors?.Any(e => e.CodigoEstudiantePatrocinador == id)).GetValueOrDefault();
        }
    }
}
