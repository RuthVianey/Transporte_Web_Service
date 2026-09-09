using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines;

public sealed class AuditoriaBussines
{
    private readonly AuditoriaDAL _dal;
    public AuditoriaBussines(AuditoriaDAL dal) => _dal = dal;
    public Task Registrar(int idEmpresa, int? idUsuario, string modulo, string accion, string recurso, string? idRegistro, string? detalle) => _dal.Registrar(idEmpresa, idUsuario, modulo, accion, recurso, idRegistro, detalle);
    public async Task<ApiResponse<IEnumerable<Entity_BitacoraAuditoria>>> Listar(int idEmpresa, DateTime? fechaInicio, DateTime? fechaFin, string? modulo)
    {
        if (idEmpresa <= 0) return ApiResponse<IEnumerable<Entity_BitacoraAuditoria>>.Fail("La empresa es obligatoria.");
        return ApiResponse<IEnumerable<Entity_BitacoraAuditoria>>.Success(await _dal.Listar(idEmpresa, fechaInicio, fechaFin, modulo));
    }
}
