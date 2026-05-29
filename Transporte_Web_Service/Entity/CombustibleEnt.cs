namespace Transporte_Web_Service.Entity
{
    public class Ent_CargaCombustible_ListarPorViaje
    {
        public int IdCarga {  get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public int IdUnidad { get; set; }
        public string NumeroEconomico { get; set; }
        public string Placas { get; set; }
        public int IdViaje {  get; set; }
        public string Fecha { get; set; }
        public string Litros { get; set; }
        public decimal PrecioLitro { get; set; }
        public decimal Importe { get; set; }
        public decimal Km { get; set; }
        public string Odometro { get; set; }
        public decimal RendimientoKmPorLitro { get; set; }
        public string Referencia { get; set; }
    }

    public class Ent_CargaCombustible_ObtenerPorId
    {
        public int IdCarga { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public int IdUnidad { get; set; }
        public string NumeroEconomico { get; set; }
        public string Placas { get; set; }
        public int IdViaje { get; set; }
        public string Fecha { get; set; }
        public decimal Litros { get; set; }
        public decimal PrecioLitro { get; set; }
        public decimal Importe { get; set; }
        public decimal Km { get; set; }
        public decimal Odometro { get; set; }
        public decimal RendimientoKmPorLitro { get; set; }
        public string Referencia { get; set; }
    }
}
