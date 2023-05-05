﻿using System;
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
    public class OrdenComprasController : Controller
    {
        private readonly QuchoochContext _context;

        public OrdenComprasController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: OrdenCompras
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var ordens = from orden in _context.OrdenCompras select orden;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                ordens = ordens.Where(s => s.CodigoOrdenCompra!.Equals(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroCodigoEstudiante"] = String.IsNullOrEmpty(ordenActual) ? "CodigoEstudianteDescendente" : "";
            ViewData["FiltroCodigoEstudiante"] = ordenActual == "CodigoEstudiante" ? "CodigoEstudianteDescendente" : "CodigoEstudianteAscendente";

            switch (ordenActual)
            {
                case "CodigoEstudianteDescendente":
                    ordens = ordens.OrderByDescending(orden => orden.CodigoOrdenCompra);
                    break;
                default:
                    ordens = ordens.OrderBy(orden => orden.CodigoOrdenCompra);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<OrdenCompra>.CrearPaginacion(ordens.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: OrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenCompras == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras
                .Include(o => o.CodigoEstudianteNavigation)
                .Include(o => o.CodigoProveedorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedors, "CodigoProveedor", "CodigoProveedor");
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoOrdenCompra,CodigoEstudiante,CodigoProveedor,FechaCreacion,Descripcion")] OrdenCompra ordenCompra)
        {
            if (ModelState != null)
            {
                _context.Add(ordenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", ordenCompra.CodigoEstudiante);
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedors, "CodigoProveedor", "CodigoProveedor", ordenCompra.CodigoProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenCompras == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", ordenCompra.CodigoEstudiante);
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedors, "CodigoProveedor", "CodigoProveedor", ordenCompra.CodigoProveedor);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoOrdenCompra,CodigoEstudiante,CodigoProveedor,FechaCreacion,Descripcion")] OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.CodigoOrdenCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraExists(ordenCompra.CodigoOrdenCompra))
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
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", ordenCompra.CodigoEstudiante);
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedors, "CodigoProveedor", "CodigoProveedor", ordenCompra.CodigoProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenCompras == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras
                .Include(o => o.CodigoEstudianteNavigation)
                .Include(o => o.CodigoProveedorNavigation)
                .FirstOrDefaultAsync(m => m.CodigoOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenCompras == null)
            {
                return Problem("Entity set 'QuchoochContext.OrdenCompras'  is null.");
            }
            var ordenCompra = await _context.OrdenCompras.FindAsync(id);
            if (ordenCompra != null)
            {
                _context.OrdenCompras.Remove(ordenCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraExists(int id)
        {
          return (_context.OrdenCompras?.Any(e => e.CodigoOrdenCompra == id)).GetValueOrDefault();
        }
    }
}
