using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transporte_Web_Service.Data
{
    public class GastosDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public GastosDAL(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<Entity_RespuestaGeneral?> Dal_Gasto_Eliminar(int IdGasto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Gasto_Eliminar",
                new
                {
                    IdGasto = IdGasto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_Gasto_Guardar(int IdGasto, int IdEmpresa, int IdSucursal, int IdTipoGasto, int IdViaje, int IdUnidad, string Fecha, decimal Monto, string Referencia, string Descripcion, byte EsFacturable)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Gasto_Guardar",
                new
                {
                    IdGasto = IdGasto,
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    IdTipoGasto = IdTipoGasto,
                    IdViaje = IdViaje,
                    IdUnidad = IdUnidad,
                    Fecha = Fecha,
                    Monto = Monto,
                    Referencia = Referencia,
                    Descripcion = Descripcion,
                    EsFacturable = EsFacturable
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_Gasto_ListarPorViaje?> Dal_Gasto_ListarPorViaje(int IdViaje, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Gasto_ListarPorViaje>("dbo.sp_Gasto_ListarPorViaje",
                new
                {
                    IdViaje = IdViaje,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Gasto_ObtenerPorId?> Dal_Gasto_ObtenerPorId(int IdGasto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Gasto_ObtenerPorId>("dbo.sp_Gasto_ObtenerPorId",
                new
                {
                    IdGasto = IdGasto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_TipoGasto_Desactivar(int IdTipoGasto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_TipoGasto_Desactivar",
                new
                {
                    IdTipoGasto = IdTipoGasto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_TipoGasto_Guardar(int IdTipoGasto, int IdEmpresa, string Descripcion, byte EsCostoDirecto, byte EsMantenimiento, byte EsCombustible, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_TipoGasto_Guardar",
                new
                {
                    IdTipoGasto = IdTipoGasto,
                    IdEmpresa = IdEmpresa,
                    Descripcion = Descripcion,
                    EsCostoDirecto = EsCostoDirecto,
                    EsMantenimiento = EsMantenimiento,
                    EsCombustible = EsCombustible,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_TipoGasto_Listar?> Dal_TipoGasto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_TipoGasto_Listar>("dbo.sp_TipoGasto_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_TipoGasto_Listar?> Dal_TipoGasto_ObtenerPorId(int IdTipoGasto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_TipoGasto_Listar>("dbo.sp_TipoGasto_ObtenerPorId",
                new
                {
                    IdTipoGasto = IdTipoGasto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}



