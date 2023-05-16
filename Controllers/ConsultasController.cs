
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ConsultasController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
