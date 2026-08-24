using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class UsuariosDAC
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UsuariosDAC(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Usuario_Guardar(int IdUsuario, int IdEmpresa, string Nombre, string Email, string Contrasenia, int? IdSucursal)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Usuario_Guardar",
                new { IdUsuario, IdEmpresa, Nombre, Email, Contrasenia, IdSucursal },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Usuario_Desactivar(int IdUsuario, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Usuario_Desactivar",
                new { IdUsuario, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Usuario_Listar?>> Usuario_Listar(int IdEmpresa, byte SoloActivos, string? TextoBusqueda)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Usuario_Listar?>("dbo.sp_Usuario_Listar",
                new { IdEmpresa, SoloActivos, TextoBusqueda },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Usuario_Listar?>> Usuario_ObtenerPorId(int IdUsuario, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Usuario_Listar?>("dbo.sp_Usuario_ObtenerPorId",
                new { IdUsuario, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }
    }
}