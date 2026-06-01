namespace Transporte_Web_Service.Entity
{
    public class Sucursal_Listar
    {
        public int IdSucursal { set; get; }
        public int IdEmpresa { set; get; }
        public string? Nombre { set; get; }
        public string? NombreCorto { set; get; }
        public string? Codigo { set; get; }
        public string? Calle { set; get; }
        public string? Colonia { set; get; }
        public string? Municipio { set; get; }
        public string? Estado { set; get; }
        public string? CodigoPostal { set; get; }
        public string? Telefono { set; get; }
        public byte Activo { set; get; }
        public string? FechaAlta { set; get; }
    }
}
