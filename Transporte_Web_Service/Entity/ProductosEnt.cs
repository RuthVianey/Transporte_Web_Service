namespace Transporte_Web_Service.Entity
{
    public class Entity_Producto_Listar
    {
        public int IdProducto { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public string? Clave { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int? IdSatCatalogoUM { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public string? UnidadMedidaDescripcion { get; set; }
        public int? IdSatCatalogoProdServ { get; set; }
        public string? ClaveSAT { get; set; }
        public string? DescripcionSAT { get; set; }
        public bool MaterialPeligroso { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
