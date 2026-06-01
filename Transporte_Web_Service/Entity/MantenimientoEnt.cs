namespace Transporte_Web_Service.Entity
{
    public class Ent_Mantenimiento_ListarPorViaje
    {
        public int IdMantenimiento {  get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int IdUnidad { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Placas { get; set; }
        public int IdViaje { get; set; }
        public int IdTipoMantenimiento { get; set; }
        public string? TipoMantenimiento { get; set; }
        public byte EsPreventivo { get; set; }
        public byte EsCorrectivo { get; set; }
        public string? Fecha { get; set; }
        public decimal KmUnidad { get; set; }
        public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
        public byte EsAsignableAViaje { get; set; }
    }

    public class Ent_Mantenimiento_ObtenerPorId
    {
        public int IdMantenimiento { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int IdUnidad { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Placas { get; set; }
        public int IdViaje { get; set; }
        public int IdTipoMantenimiento { get; set; }
        public string? TipoMantenimiento { get; set; }
        public byte EsPreventivo { get; set; }
        public byte EsCorrectivo { get; set; }
        public string? Fecha { get; set; }
        public decimal KmUnidad { get; set; }
        public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
        public byte EsAsignableAViaje { get; set; }
    }

    public class Ent_MantenimientoConcepto_ObtenerPorId
    {
        public int IdConcepto { get; set; }
        public int IdEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public byte Activo { get; set; }
    }

    public class Ent_MantenimientoDetalle_Listar
    {
        public int IdDetalle { get; set; }
        public int IdMantenimiento { get; set; }
        public int IdConcepto { get; set; }
        public string Concepto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Total { get; set; }
    }

    public class Ent_TipoMantenimiento_Listar
    {
        public int IdTipoMantenimiento { get; set; }
        public int IdEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public byte EsPreventivo { get; set; }
        public byte EsCorrectivo { get; set; }
        public byte Activo { get; set; }
    }
}
