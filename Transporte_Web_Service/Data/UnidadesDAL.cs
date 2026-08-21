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
    public class UnidadesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public UnidadesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoUnidad_Desactivar",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoUnidad_Guardar",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa,
                    Descripcion = Descripcion,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_TipoUnidad_Listar?>> Dal_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_TipoUnidad_Listar?>("dbo.sp_TipoUnidad_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoUnidad_ObtenerPorId",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Unidad_Desactivar(int IdUnidad, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Unidad_Desactivar",
                new { IdUnidad, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Unidad_Guardar(int IdUnidad, int IdEmpresa, int? IdSucursal, int IdTipoUnidad, string? NumeroEconomico, string Placas, string? Marca, string? Modelo, int? Anio, decimal? CapacidadLitros, decimal? CapacidadKg, decimal? OdometroActual, byte Activo)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Unidad_Guardar",
                new
                {
                    IdUnidad,
                    IdEmpresa,
                    IdSucursal,
                    IdTipoUnidad,
                    NumeroEconomico,
                    Placas,
                    Marca,
                    Modelo,
                    Anio,
                    CapacidadLitros,
                    CapacidadKg,
                    OdometroActual,
                    Activo
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Unidad_Listar?>> Dal_Unidad_Listar(int IdEmpresa, int? IdSucursal, byte SoloActivos, string? TextoBusqueda)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Unidad_Listar?>("dbo.sp_Unidad_Listar",
                new { IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Unidad_Listar?>> Dal_Unidad_ObtenerPorId(int IdUnidad, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Unidad_Listar?>("dbo.sp_Unidad_ObtenerPorId",
                new { IdUnidad, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }
    }
}

