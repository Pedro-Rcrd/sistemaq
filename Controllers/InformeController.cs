using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using systemquchooch.Models;

namespace systemquchooch.Controllers
{
    public class InformeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public InformeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}