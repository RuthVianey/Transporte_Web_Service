namespace Transporte_Web_Service.Entity
{
    public class Entity_Rentabilidad_ListarViajes
    {
        public int IdIdViaje { get; set; }
        public int IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
        public int IdRuta { get; set; }
        public string? Ruta { get; set; }
        public string? FechaSalida { get; set; }
        public string? FechaLlegadaReal { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public decimal KmRecorridos { get; set; }
        public decimal Ingreso { get; set; }
        public decimal GastosDirectos { get; set; }
        public decimal Combustible { get; set; }
        public decimal Mantenimiento { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Utilidad { get; set; }
        public decimal MargenPorcentaje { get; set; }
    }

    public class Entity_Rentabilidad_PorCliente
    {
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
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

    public class Entity_Rentabilidad_PorRuta
    {
        public int IdRuta { get; set; }
        public string? Ruta { get; set; }
        public int TotalViajes { get; set; }
        public decimal KmTotales { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal GastosDirectos { get; set; }
        public decimal Combustible { get; set; }
        public decimal Mantenimiento { get; set; }
        public decimal CostosFijosViaje { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal UtilidadTotal { get; set; }
        public decimal MargenPorcentaje { get; set; }
        public decimal CostoPorKm { get; set; }
    }

    public class Entity_Rentabilidad_PorUnidad
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

    public class Entity_Rentabilidad_Viaje
    {
        public int IdViaje { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
        public int IdOperador { get; set; }
        public string? Operador { get; set; }
        public int IdRuta { get; set; }
        public string? Ruta { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; };    
        public string? FechaSalida { get; set; }
        public string? FechaLlegadaReal { get; set; }        
        public decimal KmInicial { get; set; }
        public decimal KmFinal { get; set; }                                 
        public decimal KmRecorridos { get; set; }
        public decimal Ingreso { get; set; }                                
        public decimal GastosDirectos { get; set; }
        public decimal Combustible { get; set; }                             
        public decimal Mantenimiento { get; set; }
        public int DiasViaje { get; set; }   
        public decimal DepreciacionViaje { get; set; }
        public decimal SeguroViaje { get; set; }                             
        public decimal PermisosViaje { get; set; }
        public decimal GPSViaje { get; set; }                                
        public decimal FinanciamientoViaje { get; set; }
        public decimal OtrosCostosViaje { get; set; }                        
        public decimal CostosFijosViaje { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Utilidad { get; set; }
        public decimal MargenPorcentaje { get; set; }
        public decimal CostoPorKm { get; set; }
        public decimal IngresoPorKm { get; set; }                            
        public decimal UtilidadPorKm { get; set; }
        public decimal LitrosCombustible { get; set; }                       
        public decimal RendimientoKmPorLitro { get; set; }
    }
}


    