using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Security;

public sealed class PermissionMiddleware
{
    private static readonly Dictionary<string, string> Programs = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Dashboard"] = "DASHBOARD", ["Rentabilidad"] = "DASHBOARD", ["Viajes"] = "VIAJES", ["Expediente"] = "EXPEDIENTES",
        ["Gastos"] = "COSTOS", ["Combustible"] = "COSTOS", ["Mantenimiento"] = "COSTOS", ["Unidades"] = "UNIDADES",
        ["Clientes"] = "CLIENTES", ["Productos"] = "PRODUCTOS", ["Rutas"] = "RUTAS", ["Operadores"] = "OPERADORES",
        ["Sucursal"] = "SUCURSALES", ["Empresa"] = "EMPRESAS", ["General"] = "EMPRESAS", ["Roles"] = "SEGURIDAD",
        ["Usuarios"] = "SEGURIDAD", ["SatCatalogos"] = "PRODUCTOS",
        ["Alertas"] = "DASHBOARD",
    };
    private readonly RequestDelegate _next;
    public PermissionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, AuditoriaBussines auditoria)
    {
        var path = context.Request.Path.Value ?? string.Empty;
        if (!path.StartsWith("/api/", StringComparison.OrdinalIgnoreCase) || path.StartsWith("/api/Auth/", StringComparison.OrdinalIgnoreCase)) { await _next(context); return; }
        if (context.User.Identity?.IsAuthenticated != true) { await Deny(context, StatusCodes.Status401Unauthorized, "Debes iniciar sesión para continuar."); return; }
        var requestData = await ReadRequestData(context);
        var requestedCompany = context.Request.Query["IdEmpresa"].FirstOrDefault() ?? context.Request.Query["idEmpresa"].FirstOrDefault() ?? context.Request.Query["iIdEmpresa"].FirstOrDefault() ?? requestData.IdEmpresa;
        if (!string.IsNullOrWhiteSpace(requestedCompany) && requestedCompany != context.User.FindFirstValue("empresa")) { await Deny(context, StatusCodes.Status403Forbidden, "No tienes acceso a información de otra empresa."); return; }
        var controller = path.Split('/', StringSplitOptions.RemoveEmptyEntries).Skip(1).FirstOrDefault() ?? string.Empty;
        string program;
        if (controller.Equals("Auditoria", StringComparison.OrdinalIgnoreCase)) program = "SEGURIDAD";
        else if (controller.Equals("Alertas", StringComparison.OrdinalIgnoreCase)) program = "ALERTAS";
        else if (controller.Equals("Expediente", StringComparison.OrdinalIgnoreCase) && path.Contains("documento/revisar", StringComparison.OrdinalIgnoreCase)) program = "EXPEDIENTES_REVISION";
        else if (controller.Equals("Expediente", StringComparison.OrdinalIgnoreCase) && (path.Contains("documento/subir", StringComparison.OrdinalIgnoreCase) || path.Contains("documento/guardar", StringComparison.OrdinalIgnoreCase) || path.Contains("evento/guardar", StringComparison.OrdinalIgnoreCase))) program = "EXPEDIENTES_CARGA";
        else if (!Programs.TryGetValue(controller, out program)) { await Deny(context, StatusCodes.Status403Forbidden, "El módulo solicitado no está autorizado."); return; }
        var operation = GetOperation(context.Request.Method, path);
        var permissions = context.User.FindAll("permission").Select(claim => claim.Value).ToHashSet(StringComparer.OrdinalIgnoreCase);
        if (!permissions.Contains("*") && !permissions.Contains($"{program}:{operation}")) { await Deny(context, StatusCodes.Status403Forbidden, "Tu rol no tiene permiso para realizar esta acción."); return; }
        await _next(context);
        var auditAction = GetAuditAction(context.Request.Method, path, requestData, context.Request.Query["Accion"].FirstOrDefault());
        if (auditAction is not null && context.Response.StatusCode < 400
            && (!controller.Equals("Expediente", StringComparison.OrdinalIgnoreCase) || auditAction == "DESCARGAR"))
        {
            var idUsuario = int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out var user) ? user : (int?)null;
            var idEmpresa = int.Parse(context.User.FindFirstValue("empresa")!);
            var idRegistro = requestData.IdRegistro
                ?? context.Request.Query["IdViajeDocumento"].FirstOrDefault()
                ?? context.Request.Query["IdViaje"].FirstOrDefault()
                ?? context.Request.Query["IdUnidad"].FirstOrDefault()
                ?? context.Request.Query["IdMantenimiento"].FirstOrDefault()
                ?? context.Request.Query["IdGasto"].FirstOrDefault()
                ?? context.Request.Query["IdCarga"].FirstOrDefault();
            var detalle = string.IsNullOrWhiteSpace(requestData.Detalle) ? context.Request.QueryString.Value : requestData.Detalle;
            await auditoria.Registrar(idEmpresa, idUsuario, program, auditAction, path, idRegistro, detalle);
        }
    }

    private static Task Deny(HttpContext context, int status, string message) { context.Response.StatusCode = status; return context.Response.WriteAsJsonAsync(new { mensaje = message }); }
    private static string GetOperation(string method, string path)
    {
        if (method.Equals("DELETE", StringComparison.OrdinalIgnoreCase) || path.Contains("Eliminar", StringComparison.OrdinalIgnoreCase) || path.Contains("Desactivar", StringComparison.OrdinalIgnoreCase) || path.Contains("Quitar", StringComparison.OrdinalIgnoreCase)) return "D";
        return !method.Equals("GET", StringComparison.OrdinalIgnoreCase) || path.Contains("Guardar", StringComparison.OrdinalIgnoreCase) || path.Contains("Cerrar", StringComparison.OrdinalIgnoreCase) || path.Contains("Asignar", StringComparison.OrdinalIgnoreCase) || path.Contains("Subir", StringComparison.OrdinalIgnoreCase) ? "W" : "R";
    }

    private static string? GetAuditAction(string method, string path, RequestData requestData, string? accessAction)
    {
        if (path.Contains("documento/abrir", StringComparison.OrdinalIgnoreCase))
            return string.Equals(accessAction, "VISTA", StringComparison.OrdinalIgnoreCase) ? "VER" : "DESCARGAR";
        if (method.Equals("GET", StringComparison.OrdinalIgnoreCase)) return null;
        if (method.Equals("DELETE", StringComparison.OrdinalIgnoreCase) || path.Contains("Eliminar", StringComparison.OrdinalIgnoreCase) || path.Contains("Desactivar", StringComparison.OrdinalIgnoreCase)) return "ELIMINAR";
        if (path.Contains("revisar", StringComparison.OrdinalIgnoreCase)) return string.Equals(requestData.EstadoRevision, "RECHAZADO", StringComparison.OrdinalIgnoreCase) ? "RECHAZAR" : "APROBAR";
        return requestData.HasExistingId ? "MODIFICAR" : "CREAR";
    }

    private static async Task<RequestData> ReadRequestData(HttpContext context)
    {
        if (!string.Equals(context.Request.ContentType?.Split(';')[0], "application/json", StringComparison.OrdinalIgnoreCase)
            || context.Request.ContentLength is not > 0) return new RequestData();
        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;
        if (string.IsNullOrWhiteSpace(body)) return new RequestData();
        try
        {
            using var document = JsonDocument.Parse(body);
            var root = document.RootElement;
            string? Value(string name)
            {
                var property = root.EnumerateObject().FirstOrDefault(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
                return property.Value.ValueKind == JsonValueKind.Undefined ? null : property.Value.ToString();
            }
            var ids = new[] { "IdViajeDocumento", "IdEvento", "IdViajeMovimiento", "IdViaje", "IdMantenimientoProg", "IdGasto", "IdCarga", "IdUnidad", "IdOperador", "IdCliente", "IdRuta" };
            var idName = ids.FirstOrDefault(name => int.TryParse(Value(name), out var id) && id > 0);
            var id = idName is null ? null : Value(idName);
            return new RequestData(Value("IdEmpresa"), id, idName is not null && !string.Equals(idName, "IdViaje", StringComparison.OrdinalIgnoreCase), Value("EstadoRevision"), $"{idName ?? "Solicitud"}: {id ?? "nuevo"}");
        }
        catch (JsonException) { return new RequestData(); }
    }

    private sealed record RequestData(string? IdEmpresa = null, string? IdRegistro = null, bool HasExistingId = false, string? EstadoRevision = null, string? Detalle = null);
}
