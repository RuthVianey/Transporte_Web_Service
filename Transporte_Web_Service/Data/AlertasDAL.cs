using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data;

public sealed class AlertasDAL
{
    private readonly IDbConnectionFactory _connectionFactory;
    public AlertasDAL(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<IEnumerable<Entity_AlertaOperacion>> Listar(int idEmpresa, int? idSucursal)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Entity_AlertaOperacion>("dbo.sp_AlertaOperacion_Listar", new { IdEmpresa = idEmpresa, IdSucursal = idSucursal }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Entity_RespuestaGeneral?>> GuardarSeguimiento(Entity_AlertaSeguimiento_Guardar entidad)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_AlertaSeguimiento_Guardar", entidad, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Entity_AlertaSeguimientoHistorial>> Historial(int idEmpresa, string claveAlerta)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Entity_AlertaSeguimientoHistorial>("dbo.sp_AlertaSeguimiento_Historial", new { IdEmpresa = idEmpresa, ClaveAlerta = claveAlerta }, commandType: CommandType.StoredProcedure);
    }
}
