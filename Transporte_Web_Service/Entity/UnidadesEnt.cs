namespace Transporte_Web_Service.Entity
{
    public class Entity_TipoUnidad_Listar
    {
        public int IdTipoUnidad { get; set; }
        public int IdEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public byte Activo { get; set; }
    }

    public class Entity_Unidad_Listar
    {
        public int IdUnidad { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int IdTipoUnidad { get; set; }
        public string? TipoUnidad { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Placas { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }
        public decimal? CapacidadLitros { get; set; }
        public decimal? CapacidadKg { get; set; }
        public decimal? OdometroActual { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}