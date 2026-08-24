namespace Transporte_Web_Service.Entity
{
    public class Entity_Usuario_Listar
    {
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}