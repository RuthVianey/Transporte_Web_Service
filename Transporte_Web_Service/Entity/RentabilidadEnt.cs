namespace Transporte_Web_Service.Entity
{
    public class Entity_Rentabilidad_ListarViajes
    {
        public int IdIdViaje{ get; set; }
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
}
