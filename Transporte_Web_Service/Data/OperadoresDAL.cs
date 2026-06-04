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
    public class OperadoresDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public OperadoresDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Operador_Desactivar",
                new
                {
                    iIdOperador = iIdOperador,
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Operador_Guardar",
                new
                {
                    iIdOperador = iIdOperador,
                    iIdEmpresa = iIdEmpresa,
                    iIdSucursal = iIdSucursal,
                    sNombre = sNombre,
                    sLicencia = sLicencia,
                    sTipoLicencia = sTipoLicencia,
                    sFechaVencimientoLicencia = sFechaVencimientoLicencia,
                    sCURP = sCURP,
                    sTelefono = sTelefono,
                    bActivo = bActivo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Operador_ObtenerPorId?>> Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Operador_ObtenerPorId?>("dbo.sp_Operador_Listar",
                new
                {
                    iIdEmpresa = iIdEmpresa,
                    iIdSucursal = iIdSucursal,
                    bSoloActivos = bSoloActivos,
                    sTextoBusqueda = sTextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Operador_ObtenerPorId?>> Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Operador_ObtenerPorId?>("dbo.sp_Operador_ObtenerPorId",
                new
                {
                    iIdOperador = iIdOperador,
                    iIdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
