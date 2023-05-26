using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using systemquchooch.Models;
using systemquchooch.Data;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace systemquchooch.Controllers
{
    public class EstudiantesController : Controller
    {
        //AGREGANDO UN COMENTARIO
        private readonly QuchoochContext _context;

        public EstudiantesController(QuchoochContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            var estudiantes = from estudiante in _context.Estudiantes select estudiante;

            if (buscar != null)
                numpag = 1;
            else
                buscar = filtroActual;



            if (!String.IsNullOrEmpty(buscar))
            {
                estudiantes = estudiantes.Where(s => s.Nombre!.Contains(buscar));
            }
            ViewData["OrdenActual"] = ordenActual;
            ViewData["FiltroActual"] = buscar;

            ViewData["FiltroNombre"] = String.IsNullOrEmpty(ordenActual) ? "NombreDescendente" : "";

            switch (ordenActual)
            {
                case "NombreDescendente":
                    estudiantes = estudiantes.OrderByDescending(estudiante => estudiante.Nombre);
                    break;
                default:
                    estudiantes = estudiantes.OrderBy(estudiante => estudiante.Nombre);
                    break;
            }

            int cantidadregistros = 10;

            return View(await Paginacion<Estudiante>.CrearPaginacion(estudiantes.AsNoTracking(), numpag ?? 1, cantidadregistros));

        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CodigoComunidadNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["CodigoComunidad"] = new SelectList(_context.Comunidads, "CodigoComunidad", "NombreComunidad");
            return View();
        }



        // GET: Generar PDF
        public async Task<IActionResult> ImprimirEstudiantes()
        {

            // ViewModelUsuarios modelo = _context.Usuarios.Include(dv => dv.Id)
            //.Select(dv = new ViewModelUsuarios){

            //}
            return new ViewAsPdf("ImprimirEstudiantes", await _context.Estudiantes.ToListAsync()/*,modelo*/)
            {
                FileName = $"Reporte Estudiantes.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

        }



        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEstudiante,CodigoComunidad,Nombre,Apellido,FechaNacimieto,Genero,Estado,Sector,NumeroCasa,Descripcion,FotoPerfil,FechaCreacion")] Estudiante estudiante, IFormFile imageFile)
        {
            if (ModelState != null)
            {
                var resultado = AlmacenarImagen(imageFile);
                estudiante.FotoPerfil = resultado;

                //Proceso del guardado
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoComunidad"] = new SelectList(_context.Comunidads, "CodigoComunidad", "NombreComunidad", estudiante.CodigoComunidad);
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["CodigoComunidad"] = new SelectList(_context.Comunidads, "CodigoComunidad", "NombreComunidad", estudiante.CodigoComunidad);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEstudiante,CodigoComunidad,Nombre,Apellido,FechaNacimieto,Genero,Estado,Sector,NumeroCasa,Descripcion,FotoPerfil,FechaCreacion")] Estudiante estudiante, IFormFile imageFile)
        {
            if (id != estudiante.CodigoEstudiante)
            {
                return NotFound();
            }


            if (ModelState != null)
            {
                if (imageFile != null)
                {
                    var resultado = AlmacenarImagen(imageFile);
                    estudiante.FotoPerfil = resultado;
                }

                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.CodigoEstudiante))
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
            ViewData["CodigoComunidad"] = new SelectList(_context.Comunidads, "CodigoComunidad", "NombreComunidad", estudiante.CodigoComunidad);
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CodigoComunidadNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'QuchoochContext.Estudiantes'  is null.");
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiantes?.Any(e => e.CodigoEstudiante == id)).GetValueOrDefault();
        }

        public string AlmacenarImagen(IFormFile imageFile)
        {
            var cloudinary = new Cloudinary(new Account("ddxnadexi", "822983787533177", "kXxNIEGQi2SwV71mmtT5XGfmiso"));
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);
            string uniqueFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                PublicId = uniqueFileName,
                Folder = "Quchooch"
            };

            var uploadResult = cloudinary.Upload(uploadParams);


            //Transformation
            cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(100).Height(150).Crop("fill")).BuildUrl("olympic_flag");


            // Obtener la URL de la imagen guardada en Cloudinary
            var resultadoUrl = uploadResult.SecureUri.ToString();

            return (resultadoUrl);
        }
    }
}
