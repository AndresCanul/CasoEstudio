namespace EXAMEN_JN_WEB.Entities
{
    public class Solicitud
    {
        public string? Nombre { get; set; }

        public System.DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public long TipoEjercicio { get; set; }

        public string? DescripcionTipoEjercicio { get; set; }
    }
}
