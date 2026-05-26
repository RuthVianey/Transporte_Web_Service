namespace Transporte_Web_Service.Entity
{
    public class Dashboard_ViajesPorEstado
    {
        public int IdEstadoViaje { get; set; }
        public string? EstadoViaje { get; set; }
        public int TotalViajes { get; set; }
    }

    public class Dashboard_CostosPorTipo
    { 
        public string? TipoCosto { get; set; }
        public decimal Monto { get; set; }
    }
}
