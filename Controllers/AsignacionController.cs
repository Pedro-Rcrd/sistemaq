
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AsignacionController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
