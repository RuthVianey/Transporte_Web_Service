namespace Transporte_Web_Service.Entity;

public sealed class Entity_MantenimientoProgramado
{
    public int IdMantenimientoProg { get; set; }
    public int IdEmpresa { get; set; }
    public int IdUnidad { get; set; }
    public string? NumeroEconomico { get; set; }
    public string? Placas { get; set; }
    public decimal? OdometroActual { get; set; }
    public int? IdTipoMantenimiento { get; set; }
    public string? TipoMantenimiento { get; set; }
    public string? TipoServicio { get; set; }
    public decimal? KmProximo { get; set; }
    public DateTime? FechaProxima { get; set; }
    public bool Activo { get; set; }
    public string? EstadoAlerta { get; set; }
    public decimal? KmRestantes { get; set; }
    public int? DiasRestantes { get; set; }
}

public sealed class Entity_UnidadDisponible
{
    public int IdUnidad { get; set; }
    public int IdEmpresa { get; set; }
    public int? IdSucursal { get; set; }
    public string? NumeroEconomico { get; set; }
    public string? Placas { get; set; }
    public string? TipoUnidad { get; set; }
    public decimal? OdometroActual { get; set; }
    public bool Disponible { get; set; }
}

public sealed class Entity_BitacoraAuditoria
{
    public long IdBitacora { get; set; }
    public int IdEmpresa { get; set; }
    public int? IdUsuario { get; set; }
    public string? Usuario { get; set; }
    public string? Modulo { get; set; }
    public string? Accion { get; set; }
    public string? Recurso { get; set; }
    public string? IdRegistro { get; set; }
    public string? Detalle { get; set; }
    public DateTime FechaRegistro { get; set; }
}

public sealed class Entity_ValidacionCierre
{
    public string? Regla { get; set; }
    public bool Cumple { get; set; }
    public string? Mensaje { get; set; }
}

public sealed class Entity_AlertaOperacion
{
    public string? Tipo { get; set; }
    public string? Severidad { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public int? IdViaje { get; set; }
    public int? IdUnidad { get; set; }
    public DateTime? Fecha { get; set; }
}

public sealed class Entity_AlertaSeguimiento_Guardar
{
    public int IdEmpresa { get; set; }
    public string ClaveAlerta { get; set; } = string.Empty;
    public string Accion { get; set; } = string.Empty;
    public int IdUsuario { get; set; }
    public int? IdUsuarioAsignado { get; set; }
    public string? Comentario { get; set; }
}

public sealed class Entity_AlertaSeguimientoHistorial
{
    public int IdAlertaHistorial { get; set; }
    public string? Accion { get; set; }
    public string? Comentario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string? Usuario { get; set; }
}
