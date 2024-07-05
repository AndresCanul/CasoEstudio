using EXAMEN_JN_WEB.Entities;
using EXAMEN_JN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EXAMEN_JN_WEB.Controllers
{
    public class SolicitudController(ISolicitudModel iSolicitudModel) : Controller
    {
        [HttpGet]
        public IActionResult ConsultarSolicitudes()
        {
            var respuesta = iSolicitudModel.ConsultarSolicitudes();

            if (respuesta.Codigo == 1)
            {
                var datos = JsonSerializer.Deserialize<List<Solicitud>>((JsonElement)respuesta.Contenido!);
                return View(datos);
            }

            return View(new List<Solicitud>());
        }

        [HttpGet]
        public IActionResult RegistrarSolicitud()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarSolicitud(Solicitud entidad)
        {
            var respuesta = iSolicitudModel.RegistrarSolicitud(entidad);

            if (respuesta.Codigo == 1)
                return RedirectToAction("ConsultarSolicitudes", "Solicitud");

            ViewBag.MsjPantalla = respuesta.Mensaje;
            return View();
        }
    }
}
