using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class ImpuestosDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public ImpuestosDAL(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

        public async Task<IEnumerable<Entity_Impuesto?>> Dal_Impuesto_Listar(int idEmpresa, bool soloActivos)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_Impuesto?>("dbo.sp_Impuesto_Listar", new { IdEmpresa = idEmpresa, SoloActivos = soloActivos }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Impuesto_Guardar(int? idImpuesto, int idEmpresa, string descripcion, decimal? porcentaje, string operacion, string? claveSatImpuesto, string ambito, bool afectaCosto, bool activo)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Impuesto_Guardar", new { IdImpuesto = idImpuesto, IdEmpresa = idEmpresa, Descripcion = descripcion, Porcentaje = porcentaje, Operacion = operacion, ClaveSatImpuesto = claveSatImpuesto, Ambito = ambito, AfectaCosto = afectaCosto, Activo = activo }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_ProductoImpuesto?>> Dal_ProductoImpuesto_Listar(int idEmpresa, int idProducto, bool soloActivos)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_ProductoImpuesto?>("dbo.sp_ProductoImpuesto_Listar", new { IdEmpresa = idEmpresa, IdProducto = idProducto, SoloActivos = soloActivos }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ProductoImpuesto_Guardar(int idEmpresa, int idProducto, int idImpuesto, bool activo)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ProductoImpuesto_Guardar", new { IdEmpresa = idEmpresa, IdProducto = idProducto, IdImpuesto = idImpuesto, Activo = activo }, commandType: CommandType.StoredProcedure);
        }
    }
}
