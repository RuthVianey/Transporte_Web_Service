namespace Transporte_Web_Service.Entity
{
    public class Ent_Gasto_ListarPorViaje
    {
        public int IdGasto {  get; set; }
            public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public int IdTipoGasto { get; set; }
        public string TipoGasto { get; set; }
        public byte EsCostoDirecto { get; set; }
        public byte EsMantenimiento { get; set; }
        public byte EsCombustible { get; set; }
        public int IdViaje { get; set; }
        public int IdUnidad { get; set; }
        public string NumeroEconomico { get; set; }
        public string Placas { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public byte EsFacturable { get; set; }
    }

    public class Ent_Gasto_ObtenerPorId
    {
        public int IdGasto { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public int IdTipoGasto { get; set; }
        public string TipoGasto { get; set; }
        public byte EsCostoDirecto { get; set; }
        public byte EsMantenimiento { get; set; }
        public byte EsCombustible { get; set; }
        public int IdViaje { get; set; }
        public int IdUnidad { get; set; }
        public string NumeroEconomico { get; set; }
        public string Placas { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public byte EsFacturable { get; set; }
    }
}
