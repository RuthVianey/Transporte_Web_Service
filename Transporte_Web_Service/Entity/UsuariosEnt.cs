namespace Transporte_Web_Service.Entity
{
    public class Entity_Lista_Roles
    {
        public int? IdRol { set; get; }
        public string Nombre { set; get; }
    }

    public class Entity_Lista_Usuario
    {
        public int? IdUsuario { set; get; }
        public string Nombre { set; get; }
        public string Email { set; get; }
    }

    public class Entity_Lista_Programa
    {
        public int? IdPrograma { set; get; }
        public string Nombre { set; get; }
    }

    public class Entity_RespuestaGeneral
    {
        public int? Resultado { set; get; }
        public string? Mensaje { set; get; }
        public int? ID { set; get; }
    }

    public class Entity_Operador_ObtenerPorId
    {
        public int? IdOperador { set; get; }
        public int? IdEmpresa { set; get; }
        public int? IdSucursal { set; get; }
        public string Sucursal { set; get; }
        public string Nombre { set; get; }
        public string Licencia { set; get; }
        public string TipoLicencia { set; get; }
        public string FechaVencimientoLicencia { set; get; }
        public string CURP { set; get; }
        public string Telefono { set; get; }
        public string Activo { set; get; }
    }

    public class Entity_RutaDetalle_ObtenerPorId
    {
        public int? IdRutaDetalle { set; get; }
        public int? IdRuta { set; get; }
        public int? Orden { set; get; }
        public string Punto { set; get; }
        public decimal? Latitud { set; get; }
        public decimal? Longitud { set; get; }
        public string Tipo { set; get; }
    }

    public class Entity_Ruta_ObtenerPorId
    {
        public int? IdRuta { set; get; }
        public int? IdEmpresa { set; get; }
        public int? IdSucursal { set; get; }
        public string Sucursal { set; get; }
        public string Nombre { set; get; }
        public string Origen { set; get; }
        public string Destino { set; get; }
        public decimal? DistanciaKm { set; get; }
        public int TiempoEstimadoMin { set; get; }
        public byte Activo { set; get; }
    }
    
}
