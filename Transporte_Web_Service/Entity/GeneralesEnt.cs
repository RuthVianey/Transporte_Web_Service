namespace Transporte_Web_Service.Entity
{
    public class Obtienen_Datos_Empresa
    {
        public string Nombre_Completo { set; get; }
        public string Nombre_Corto { set; get; }
        public string RFC { set; get; }
        public string Calle { set; get; }
        public string Colonia { set; get; }
        public string Municipio { set; get; }
        public string Estado { set; get; }
        public string Codigo_Postal { set; get; }
        public string Telefono { set; get; }
        public string RutaLogo { set; get; }
    }

    public class Usuarios_Empresa
    {
        public int? IdEmpresa { set; get; }
        public string Nombre_Corto { set; get; }
    }

    public class Empresa_Listar
    {
        public int? IdEmpresa { set; get; }
        public string Nombre { set; get; }
        public string NombreCorto { set; get; }
        public string RFC { set; get; }
        public string Calle { set; get; }
        public string Colonia { set; get; }
        public string Municipio { set; get; }
        public string Estado { set; get; }
        public string CodigoPostal { set; get; }
        public string Telefono { set; get; }
        public string RutaLogo { set; get; }
        public byte? Activo { set; get; }
        public string FechaAlta { set; get; }
    }
}
