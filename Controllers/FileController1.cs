using Microsoft.AspNetCore.Mvc;

namespace systemquchooch.Controllers
{
    public class FileController1 : Controller
    {
        public IActionResult MostrarImagen()
        {
            return File(@"~/images/iroMan.jpg", @"image/jpeg");
        }
    }
}
