namespace Transporte_Web_Service.Entity
{
    public class Ent_Ruta_Listar
    {
        public int IdRuta {  get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public string Nombre { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal DistanciaKm { get; set; }
        public int TiempoEstimadoMin { get; set; }
        public byte Activo { get; set; }
    }

    public class Ent_RutaDetalle_Listar
    {

    }
}
