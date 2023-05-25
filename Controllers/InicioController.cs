using Microsoft.AspNetCore.Mvc;

using systemquchooch.Models;
using systemquchooch.Recursos;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;


namespace systemquchooch.Controllers
{
    public class InicioController : Controller
    {
        private readonly systemquchooch.Servicios.Contrato.IUsuarioService _usuarioServicio;
        public InicioController(systemquchooch.Servicios.Contrato.IUsuarioService usuarioServicio)
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
            var password = Utilidades.Encriptarcontrasena(modelo.Contrasena);
            Console.WriteLine(password);
            modelo.Contrasena = password;

            Usuario Usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (Usuario_creado.Apellido.Length != 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string email, string contrasena)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(email, Utilidades.Encriptarcontrasena(contrasena));

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.Apellido)
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
