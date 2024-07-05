using Dapper;
using EXAMEN_JN_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EXAMEN_JN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController(IConfiguration iConfiguration) : ControllerBase
    {
        [HttpPost]
        [Route("RegistrarSolicitud")]
        public async Task<IActionResult> RegistrarSolicitud(Solicitud entidad)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = await db.ExecuteAsync("RegistrarSolicitud", new { entidad.Nombre, entidad.Monto, entidad.TipoEjercicio }, commandType: CommandType.StoredProcedure);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Se registró el cliente en el ejercicio exitosamente";
                    respuesta.Contenido = true;
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "El cliente ya se encuentra registrado en dos ejercicios";
                    respuesta.Contenido = false;
                    return Ok(respuesta);
                }
            }
        }

        [HttpGet]
        [Route("ConsultarSolicitudes")]
        public async Task<IActionResult> ConsultarSolicitudes()
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = await db.QueryAsync<Solicitud>("ConsultarSolicitudes", new { }, commandType: CommandType.StoredProcedure);

                if (resultado.Count() > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de las inscripciones se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No hay clientes registrados en los ejercicios en este momento";
                    respuesta.Contenido = false;
                    return Ok(respuesta);
                }
            }
        }
    }
}

