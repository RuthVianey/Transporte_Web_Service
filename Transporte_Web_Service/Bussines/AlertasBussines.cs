using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines;

public sealed class AlertasBussines
{
    private readonly AlertasDAL _dal;
    public AlertasBussines(AlertasDAL dal) => _dal = dal;
    public async Task<ApiResponse<IEnumerable<Entity_AlertaOperacion>>> Listar(int idEmpresa, int? idSucursal)
    {
        if (idEmpresa <= 0) return ApiResponse<IEnumerable<Entity_AlertaOperacion>>.Fail("La empresa es obligatoria.");
        return ApiResponse<IEnumerable<Entity_AlertaOperacion>>.Success(await _dal.Listar(idEmpresa, idSucursal));
    }

    public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> GuardarSeguimiento(Entity_AlertaSeguimiento_Guardar entidad)
    {
        if (entidad.IdEmpresa <= 0 || entidad.IdUsuario <= 0 || string.IsNullOrWhiteSpace(entidad.ClaveAlerta)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Empresa, alerta y usuario son obligatorios.");
        if (!new[] { "ASIGNAR", "ATENDER", "REABRIR" }.Contains(entidad.Accion.Trim().ToUpperInvariant())) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Acción de alerta no válida.");
        return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(await _dal.GuardarSeguimiento(entidad));
    }

    public async Task<ApiResponse<IEnumerable<Entity_AlertaSeguimientoHistorial>>> Historial(int idEmpresa, string claveAlerta)
    {
        if (idEmpresa <= 0 || string.IsNullOrWhiteSpace(claveAlerta)) return ApiResponse<IEnumerable<Entity_AlertaSeguimientoHistorial>>.Fail("Empresa y alerta son obligatorias.");
        return ApiResponse<IEnumerable<Entity_AlertaSeguimientoHistorial>>.Success(await _dal.Historial(idEmpresa, claveAlerta));
    }
}
