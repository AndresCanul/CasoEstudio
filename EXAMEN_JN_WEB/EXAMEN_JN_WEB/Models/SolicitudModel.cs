using EXAMEN_JN_WEB.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace EXAMEN_JN_WEB.Models
{
    public class SolicitudModel(HttpClient httpClient, IConfiguration iConfiguration) : ISolicitudModel
    {
        public Respuesta RegistrarSolicitud(Solicitud entidad)
        {
            using (httpClient)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Solicitud/RegistrarSolicitud";
                JsonContent body = JsonContent.Create(entidad);
                var respuesta = httpClient.PostAsync(url, body).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }

        public Respuesta ConsultarSolicitudes()
        {
            using (httpClient)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Solicitud/ConsultarSolicitudes";
                var respuesta = httpClient.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }
    }
}
