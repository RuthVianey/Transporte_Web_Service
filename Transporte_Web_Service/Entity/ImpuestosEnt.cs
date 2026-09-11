namespace Transporte_Web_Service.Entity
{
    public class Entity_Impuesto
    {
        public int IdImpuesto { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Porcentaje { get; set; }
        public string Operacion { get; set; } = "+";
        public string? ClaveSatImpuesto { get; set; }
        public string Ambito { get; set; } = "F";
        public bool AfectaCosto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Entity_ProductoImpuesto
    {
        public int IdProductoImpuesto { get; set; }
        public int IdProducto { get; set; }
        public int IdImpuesto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Porcentaje { get; set; }
        public string Operacion { get; set; } = "+";
        public string? ClaveSatImpuesto { get; set; }
        public string Ambito { get; set; } = "F";
        public bool AfectaCosto { get; set; }
        public bool Activo { get; set; }
    }
}
