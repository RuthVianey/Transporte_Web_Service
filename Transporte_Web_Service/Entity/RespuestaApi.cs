namespace Transporte_Web_Service.Entity
{
    public class RespuestaApi
    {
        public int Estatus { get; set; } = 1; // 1 = Ok, 0 = Sin datos, -1 = Error
        public string Mensaje { get; set; } = "Operación exitosa.";
        public object? Datos { get; set; }
    }
}
