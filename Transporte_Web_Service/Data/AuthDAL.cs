using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class AuthDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AuthDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int?> Usuario_Valida(int IdEmpresa, string Email, string PasswordIngresado)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<int?>("dbo.sp_Usuario_Valida",
                new
                {
                    IdEmpresa = IdEmpresa,
                    Email = Email,
                    PasswordIngresado = PasswordIngresado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_UsuarioEmpresa?>> Usuarios_Empresa(string Email)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_UsuarioEmpresa?>("dbo.sp_Usuarios_Empresa",
                new
                {
                    Email = Email.Trim()
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
