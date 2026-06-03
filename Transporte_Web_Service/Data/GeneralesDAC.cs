
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
    public class GeneralesDAC //: ConexionBD
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public GeneralesDAC(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        /*COMIENZA EMPRESA*/
        public async Task<Entity_RespuestaGeneral?> Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Empresa_Guardar",
                new
                {
                    iIdEmpresa = iIdEmpresa,
                    sNombre = sNombre,
                    sNombre_Corto = sNombre_Corto,
                    sRFC = sRFC,
                    sCalle = sCalle,
                    sColonia = sColonia,
                    sMunicipio = sMunicipio,
                    sEstado = sEstado,
                    sCodigo_Postal = sCodigo_Postal,
                    sTelefono = sTelefono,
                    sRutaLogo = sRutaLogo,
                    bActivo = bActivo
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_RespuestaGeneral?> Empresa_Desactivar(int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Empresa_Desactivar",
                new
                {
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Empresa_Listar?> Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Empresa_Listar>("dbo.sp_Empresa_Listar",
                new
                {
                    bSoloActivos = bSoloActivos,
                    sTextoBusqueda = sTextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Empresa_Listar?> Empresa_ObtenerPorId(int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Empresa_Listar>("dbo.sp_Empresa_ObtenerPorId",
                new
                {
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Programa_Listar?> Dal_Programa_Listar()
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Programa_Listar>("dbo.Programa_Listar",
                new
                {
                     
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
