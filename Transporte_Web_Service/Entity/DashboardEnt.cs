namespace Transporte_Web_Service.Entity
{
    
    public class Entity_Dashboard_CostosPorTipo
    { 
        public string? TipoCosto { get; set; }
        public decimal Monto { get; set; }
    }
  
    public class Entity_Dashboard_ResumenOperativo
    {
        public int TotalViajes { get; set; }
        public int ViajesPendientes { get; set; }
        public int ViajesEnCurso { get; set; }
        public int ViajesCerrados { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal GastosDirectos { get; set; }
        public decimal Combustible { get; set; }
        public decimal Mantenimiento { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal UtilidadTotal { get; set; }
        public decimal MargenPorcentaje { get; set; }
        public decimal KmTotales { get; set; }
        public decimal CostoPorKm { get; set; }
        public decimal LitrosCombustible { get; set; }
        public decimal RendimientoKmPorLitro { get; set; }
}

    public class Entity_Dashboard_RentabilidadMensual
    {
        public int Mes { get; set; }
        public string? NombreMes { get; set; }
        public int TotalViajes { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal UtilidadTotal { get; set; }
    }

    public class Entity_Dashboard_TopClientes
    {
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
        public int TotalViajes { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal UtilidadTotal { get; set; }
        public decimal MargenPorcentaje { get; set; }
    }

    public class Entity_Dashboard_TopUnidades
    {
        public int IdUnidad { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Placas { get; set; }
        public string? TipoUnidad { get; set; }
        public int TotalViajes { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal GastosDirectos { get; set; } 
        public decimal Combustible { get; set; }
        public decimal Mantenimiento { get; set; }
        public decimal CostosFijosViaje { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal UtilidadTotal { get; set; }
        public decimal MargenPorcentaje { get; set; }
    }

    public class Entity_Dashboard_ViajesPorEstado
    {
        public int IdEstadoViaje { get; set; }
        public string? EstadoViaje { get; set; }
        public int TotalViajes { get; set; }
    }
}

