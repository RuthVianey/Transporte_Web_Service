namespace Transporte_Web_Service.Entity
{
    public class Entity_Viaje_Listar
    {
        public int IdViaje { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string? Sucursal { get; set; }
        public int? IdOperador { get; set; }
        public string? Operador { get; set; }
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
        public int? IdRuta { get; set; }
        public string? Ruta { get; set; }
        public int IdEstadoViaje { get; set; }
        public string? EstadoViaje { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaLlegadaEstimada { get; set; }
        public DateTime? FechaLlegadaReal { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public decimal? KmInicial { get; set; }
        public decimal? KmFinal { get; set; }
        public decimal? KmRecorridos { get; set; }
        public decimal Ingreso { get; set; }
        public decimal? PrecioPactado { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal TotalCarga { get; set; }
        public decimal TotalDescarga { get; set; }
        public decimal DiferenciaCarga { get; set; }
        public int Cargas { get; set; }
        public int Descargas { get; set; }
    }

    public class Entity_ViajeMovimiento_Listar
    {
        public int IdViajeMovimiento { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public int IdViaje { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty;
        public int Secuencia { get; set; }
        public DateTime? FechaMovimiento { get; set; }
        public string? Lugar { get; set; }
        public string? ClienteDestino { get; set; }
        public string? Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public decimal? Temperatura { get; set; }
        public decimal? Densidad { get; set; }
        public string? Referencia { get; set; }
        public string? Observaciones { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}

