using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RegistroController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Auxiliar()
        {
            return View();
        }


    }
}