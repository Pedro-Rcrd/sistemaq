using Microsoft.AspNetCore.Mvc;


using systemquchooch.Models;
using systemquchooch.Recursos;
using systemquchooch.Servicios.Contrato;

//USAR COOKIES PARA EL LOGIN
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace systemquchooch.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        //CONSTRUCTOR DE LA CLASE
        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Contrasena = Utilidades.EncriptarClave(modelo.Contrasena);

            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);
            if(usuario_creado.CodigoUsuario > 0)
            return RedirectToAction("IniciarSesion", "Inicio");


            ViewData["Mensaje"] = "No se pudo crear el usuario";


            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuarios(correo, Utilidades.EncriptarClave(clave));

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencia";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );


            return RedirectToAction("Index", "Home");
        }
    }
}

