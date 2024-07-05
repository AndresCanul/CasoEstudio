using EXAMEN_JN_WEB.Entities;

namespace EXAMEN_JN_WEB.Models
{
    public interface ISolicitudModel
    {
        Respuesta RegistrarSolicitud(Solicitud entidad);

        Respuesta ConsultarSolicitudes();
    }
}
