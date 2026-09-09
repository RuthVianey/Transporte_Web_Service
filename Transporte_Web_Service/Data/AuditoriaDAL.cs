using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data;

public sealed class AuditoriaDAL
{
    private readonly IDbConnectionFactory _connectionFactory;
    public AuditoriaDAL(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

    public async Task Registrar(int idEmpresa, int? idUsuario, string modulo, string accion, string recurso, string? idRegistro, string? detalle)
    {
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync("dbo.sp_BitacoraAuditoria_Guardar", new { IdEmpresa = idEmpresa, IdUsuario = idUsuario, Modulo = modulo, Accion = accion, Recurso = recurso, IdRegistro = idRegistro, Detalle = detalle }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Entity_BitacoraAuditoria>> Listar(int idEmpresa, DateTime? fechaInicio, DateTime? fechaFin, string? modulo)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Entity_BitacoraAuditoria>("dbo.sp_BitacoraAuditoria_Listar", new { IdEmpresa = idEmpresa, FechaInicio = fechaInicio, FechaFin = fechaFin, Modulo = modulo }, commandType: CommandType.StoredProcedure);
    }
}
