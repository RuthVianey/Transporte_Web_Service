using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers;

public abstract class AuditableController : ControllerBase
{
    private readonly AuditoriaBussines _auditoria;

    protected AuditableController(AuditoriaBussines auditoria) => _auditoria = auditoria;

    protected bool OperacionExitosa(ApiResponse<IEnumerable<Entity_RespuestaGeneral?>> response) =>
        response.Ok && response.Data?.FirstOrDefault()?.Resultado > 0;

    protected Task RegistrarAuditoria(
        int idEmpresa,
        string modulo,
        string accion,
        string recurso,
        int? idRegistro,
        string? detalle)
    {
        var idUsuario = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var usuario)
            ? usuario
            : (int?)null;
        return _auditoria.Registrar(idEmpresa, idUsuario, modulo, accion, recurso, idRegistro?.ToString(), detalle);
    }
}
