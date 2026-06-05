using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class AuthDAL
    {
        //private readonly MiDbContext _context;
        //private readonly IDbConnectionFactory _connectionFactory;
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

        public async Task<Entity_RespuestaGeneral?> Usuarios_Empresa(string Email)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Usuarios_Empresa",
                new
                {
                    Email = Email
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
