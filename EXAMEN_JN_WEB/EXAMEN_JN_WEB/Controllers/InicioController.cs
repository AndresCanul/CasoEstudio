using Microsoft.AspNetCore.Mvc;

namespace EXAMEN_JN_WEB.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult PantallaPrincipal()
        {
            return View();
        }
    }
}
