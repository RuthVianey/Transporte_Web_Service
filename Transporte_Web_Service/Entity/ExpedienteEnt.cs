namespace Transporte_Web_Service.Entity
{
    public class Entity_TipoDocumentoViaje_Guardar
    {
        public int? IdTipoDocumentoViaje { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string? Clave { get; set; }
        public bool AplicaCarga { get; set; }
        public bool AplicaDescarga { get; set; }
        public bool AplicaCierre { get; set; }
        public bool Requerido { get; set; }
        public bool Activo { get; set; } = true;
    }

    public class Entity_TipoDocumentoViaje_Listar
    {
        public int IdTipoDocumentoViaje { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string? Clave { get; set; }
        public bool AplicaCarga { get; set; }
        public bool AplicaDescarga { get; set; }
        public bool AplicaCierre { get; set; }
        public bool Requerido { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Entity_ViajeDocumento_Guardar
    {
        public int? IdViajeDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public int IdViaje { get; set; }
        public int? IdEvento { get; set; }
        public int? IdTipoDocumentoViaje { get; set; }
        public int? IdUsuarioCarga { get; set; }
        public string? TipoEvento { get; set; }
        public string NombreOriginal { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public string? Extension { get; set; }
        public string? ContentType { get; set; }
        public string RutaRelativa { get; set; } = string.Empty;
        public long? TamanoBytes { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }

    public class Entity_ViajeDocumento_Listar
    {
        public int IdViajeDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public int IdViaje { get; set; }
        public int? IdEvento { get; set; }
        public int? IdTipoDocumentoViaje { get; set; }
        public string? TipoDocumento { get; set; }
        public int? IdUsuarioCarga { get; set; }
        public string? UsuarioCarga { get; set; }
        public string? TipoEvento { get; set; }
        public string NombreOriginal { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public string? Extension { get; set; }
        public string? ContentType { get; set; }
        public string RutaRelativa { get; set; } = string.Empty;
        public long? TamanoBytes { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public DateTime FechaCarga { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool Activo { get; set; }
    }

    public class Entity_ViajeDocumento_Subir
    {
        public int IdEmpresa { get; set; }
        public int? IdSucursal { get; set; }
        public int IdViaje { get; set; }
        public int? IdEvento { get; set; }
        public int? IdTipoDocumentoViaje { get; set; }
        public int? IdUsuarioCarga { get; set; }
        public string? TipoEvento { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
}

namespace Transporte_Web_Service.Entity
{
    public class Entity_ViajeExpediente_Obtener
    {
        public IEnumerable<dynamic> Viaje { get; set; } = Enumerable.Empty<dynamic>();
        public IEnumerable<dynamic> Eventos { get; set; } = Enumerable.Empty<dynamic>();
        public IEnumerable<dynamic> Documentos { get; set; } = Enumerable.Empty<dynamic>();
    }
}
