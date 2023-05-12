using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using systemquchooch.Data;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class FichaCalificacionsController : Controller
    {
        private readonly QuchoochContext _context;

        public FichaCalificacionsController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: FichaCalificacions
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var variables = from variable in _context.FichaCalificacions select variable;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                variables = variables.Where(s => s.Notas!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            variables = ordenActual switch
            {
                "NombreDescendente" => variables.OrderByDescending(grado => grado.Notas),
                _ => variables.OrderBy(grado => grado.Notas),
            };
            int cantidadregistros = 10;

            return View(await Paginacion<FichaCalificacion>.CrearPaginacion(variables.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: FichaCalificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FichaCalificacions == null)
            {
                return NotFound();
            }

            var fichaCalificacion = await _context.FichaCalificacions
                .Include(f => f.CodigoDesempeñoNavigation)
                .Include(f => f.CodigoEstudianteNavigation)
                .Include(f => f.CodigoPeriodoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoFichaCalificacion == id);
            if (fichaCalificacion == null)
            {
                return NotFound();
            }

            return View(fichaCalificacion);
        }

        // GET: FichaCalificacions/Create
        public IActionResult Create()
        {
            ViewData["CodigoDesempeño"] = new SelectList(_context.Desempeños, "CodigoDesempeño", "CodigoDesempeño");
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["CodigoPeriodo"] = new SelectList(_context.Periodos, "CodigoPeriodo", "CodigoPeriodo");
            return View();
        }


	 // GET: Generar PDF
        public async Task<IActionResult> ImprimirFichaCalificacions()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirFichaCalificacions", await _context.FichaCalificacions.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte FichaCalificacions.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }

        // POST: FichaCalificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoFichaCalificacion,CodigoEstudiante,CodigoPeriodo,CodigoDesempeño,FechaEntrega,Notas,Promedio,ImagenFicha,ImagenEstudiante,ImagenCarta")] FichaCalificacion fichaCalificacion)
        {
            if (ModelState != null)
            {
                _context.Add(fichaCalificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoDesempeño"] = new SelectList(_context.Desempeños, "CodigoDesempeño", "CodigoDesempeño", fichaCalificacion.CodigoDesempeño);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", fichaCalificacion.CodigoEstudiante);
            ViewData["CodigoPeriodo"] = new SelectList(_context.Periodos, "CodigoPeriodo", "CodigoPeriodo", fichaCalificacion.CodigoPeriodo);
            return View(fichaCalificacion);
        }

        // GET: FichaCalificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FichaCalificacions == null)
            {
                return NotFound();
            }

            var fichaCalificacion = await _context.FichaCalificacions.FindAsync(id);
            if (fichaCalificacion == null)
            {
                return NotFound();
            }
            ViewData["CodigoDesempeño"] = new SelectList(_context.Desempeños, "CodigoDesempeño", "CodigoDesempeño", fichaCalificacion.CodigoDesempeño);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", fichaCalificacion.CodigoEstudiante);
            ViewData["CodigoPeriodo"] = new SelectList(_context.Periodos, "CodigoPeriodo", "CodigoPeriodo", fichaCalificacion.CodigoPeriodo);
            return View(fichaCalificacion);
        }

        // POST: FichaCalificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoFichaCalificacion,CodigoEstudiante,CodigoPeriodo,CodigoDesempeño,FechaEntrega,Notas,Promedio,ImagenFicha,ImagenEstudiante,ImagenCarta")] FichaCalificacion fichaCalificacion)
        {
            if (id != fichaCalificacion.CodigoFichaCalificacion)
            {
                return NotFound();
            }

            if (ModelState != null)
            {
                try
                {
                    _context.Update(fichaCalificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaCalificacionExists(fichaCalificacion.CodigoFichaCalificacion))
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
            ViewData["CodigoDesempeño"] = new SelectList(_context.Desempeños, "CodigoDesempeño", "CodigoDesempeño", fichaCalificacion.CodigoDesempeño);
            ViewData["CodigoEstudiante"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", fichaCalificacion.CodigoEstudiante);
            ViewData["CodigoPeriodo"] = new SelectList(_context.Periodos, "CodigoPeriodo", "CodigoPeriodo", fichaCalificacion.CodigoPeriodo);
            return View(fichaCalificacion);
        }

        // GET: FichaCalificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FichaCalificacions == null)
            {
                return NotFound();
            }

            var fichaCalificacion = await _context.FichaCalificacions
                .Include(f => f.CodigoDesempeñoNavigation)
                .Include(f => f.CodigoEstudianteNavigation)
                .Include(f => f.CodigoPeriodoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoFichaCalificacion == id);
            if (fichaCalificacion == null)
            {
                return NotFound();
            }

            return View(fichaCalificacion);
        }

        // POST: FichaCalificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FichaCalificacions == null)
            {
                return Problem("Entity set 'QuchoochContext.FichaCalificacions'  is null.");
            }
            var fichaCalificacion = await _context.FichaCalificacions.FindAsync(id);
            if (fichaCalificacion != null)
            {
                _context.FichaCalificacions.Remove(fichaCalificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichaCalificacionExists(int id)
        {
          return (_context.FichaCalificacions?.Any(e => e.CodigoFichaCalificacion == id)).GetValueOrDefault();
        }
    }
}
