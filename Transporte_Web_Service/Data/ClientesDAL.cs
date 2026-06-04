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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transporte_Web_Service.Data
{
    public class ClientesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public ClientesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<Entity_RespuestaGeneral?> Dal_Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Cliente_Desactivar",
                new
                {
                    iIdCliente = iIdCliente,
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_RespuestaGeneral?> Dal_Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Cliente_Guardar",
                new
                {
                    iIdCliente = iIdCliente,
                    iIdEmpresa = iIdEmpresa,
                    iIdSucursal = iIdSucursal,
                    sNombre = sNombre,
                    sRFC = sRFC,
                    sTelefono = sTelefono,
                    sEmail = sEmail,
                    iRegimenFiscal = iRegimenFiscal,
                    bActivo = bActivo
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_Obtener_Cliente_PorId?> Dal_Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Obtener_Cliente_PorId>("dbo.sp_Cliente_Listar",
                new
                {
                    iIdEmpresa = iIdEmpresa,
                    iIdSucursal = iIdSucursal,
                    sSoloActivos = sSoloActivos,
                    sTextoBusqueda = sTextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        
        public async Task<Entity_Obtener_Cliente_PorId?> Dal_Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Obtener_Cliente_PorId>("dbo.sp_Cliente_ObtenerPorId",
                new
                {
                    iIdCliente = iIdCliente,
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
