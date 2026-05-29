namespace Transporte_Web_Service.Entity
{
    public class Ent_Obtener_Cliente_PorId
    {
        public int? IdCliente { set; get; }
        public int? IdEmpresa { set; get; }
        public int? IdSucursal { set; get; }
        public string Sucursal { set; get; }
        public string Nombre { set; get; }
        public string RFC { set; get; }
        public string Telefono { set; get; }
        public string Email { set; get; }
        public string RegimenFiscal { set; get; }
        public byte Activo { set; get; }
    }

    
}
