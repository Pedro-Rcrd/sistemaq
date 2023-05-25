﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using systemquchooch.Models;
using systemquchooch.Data;

namespace systemquchooch.Controllers
{
    public class NivelAcademicoesController : Controller
    {
        private readonly QuchoochContext _context;

        public NivelAcademicoesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: NivelAcademicoes
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var nivelacademicos = from nivelacademico in _context.NivelAcademicos select nivelacademico;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                nivelacademicos = nivelacademicos.Where(s => s.Nombre!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            nivelacademicos = ordenActual switch
            {
                "NombreDescendente" => nivelacademicos.OrderByDescending(nivelAcademico => nivelAcademico.Nombre),
                _ => nivelacademicos.OrderBy(nivelAcademico => nivelAcademico.Nombre),
            };
            int cantidadregistros = 10;

            return View(await Paginacion<NivelAcademico>.CrearPaginacion(nivelacademicos.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }
        // GET: NivelAcademicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelAcademicos == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademicos
                .FirstOrDefaultAsync(m => m.CodigoNivelAcademico == id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }

            return View(nivelAcademico);
        }

        // GET: NivelAcademicoes/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: Generar PDF
        public async Task<IActionResult> ImprimirNivel()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirNivel", await _context.NivelAcademicos.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte NivelAcademicos.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }


        // POST: NivelAcademicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoNivelAcademico,Nombre")] NivelAcademico nivelAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelAcademico);
        }

        // GET: NivelAcademicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelAcademicos == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademicos.FindAsync(id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }
            return View(nivelAcademico);
        }

        // POST: NivelAcademicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoNivelAcademico,Nombre")] NivelAcademico nivelAcademico)
        {
            if (id != nivelAcademico.CodigoNivelAcademico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelAcademicoExists(nivelAcademico.CodigoNivelAcademico))
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
            return View(nivelAcademico);
        }

        // GET: NivelAcademicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelAcademicos == null)
            {
                return NotFound();
            }

            var nivelAcademico = await _context.NivelAcademicos
                .FirstOrDefaultAsync(m => m.CodigoNivelAcademico == id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }

            return View(nivelAcademico);
        }

        // POST: NivelAcademicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelAcademicos == null)
            {
                return Problem("Entity set 'QuchoochContext.NivelAcademicos'  is null.");
            }
            var nivelAcademico = await _context.NivelAcademicos.FindAsync(id);
            if (nivelAcademico != null)
            {
                _context.NivelAcademicos.Remove(nivelAcademico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelAcademicoExists(int id)
        {
            return (_context.NivelAcademicos?.Any(e => e.CodigoNivelAcademico == id)).GetValueOrDefault();
        }
    }
}
