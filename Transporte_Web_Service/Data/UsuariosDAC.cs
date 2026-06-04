using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transporte_Web_Service.Data
{
    public class UsuariosDAC
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public UsuariosDAC(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        /*COMIENZA USUARIO*/
        public async Task<Entity_RespuestaGeneral?> Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Usuario_Guardar",
                new
                {
                    iIdUsuario = iIdUsuario,
                    iIdEmpresa = iIdEmpresa,
                    sNombre = sNombre,
                    sEmail = sEmail,
                    sContrasenia = sContrasenia,
                    iIdSucursal = iIdSucursal
                },
                commandType: CommandType.StoredProcedure
            );
        }        
    }
}
