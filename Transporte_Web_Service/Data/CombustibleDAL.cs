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
    public class CombustibleDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public CombustibleDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_CargaCombustible_Eliminar(int IdCarga, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral>("dbo.sp_CargaCombustible_Eliminar",
                new
                {
                    IdCarga = IdCarga,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_CargaCombustible_Guardar(int IdCarga, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, string Fecha, decimal Litros, decimal PrecioLitro, decimal Km, decimal Odometro, decimal RendimientoKmPorLitro, string Referencia)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral>("dbo.sp_CargaCombustible_Guardar",
                new
                {
                    IdCarga = IdCarga,
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    IdUnidad = IdUnidad,
                    IdViaje = IdViaje,
                    Fecha = Fecha,
                    Litros = Litros,
                    PrecioLitro = PrecioLitro,
                    Km = Km,
                    Odometro = Odometro,
                    RendimientoKmPorLitro = RendimientoKmPorLitro,
                    Referencia = Referencia,
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<IEnumerable<Entity_CargaCombustible_ListarPorViaje?>> Dal_CargaCombustible_ListarPorViaje(int IdEmpresa, int IdViaje)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_CargaCombustible_ListarPorViaje>("dbo.sp_CargaCombustible_ListarPorViaje",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdViaje = IdViaje,
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_CargaCombustible_ObtenerPorId?>> Dal_CargaCombustible_ObtenerPorId(int IdEmpresa, int IdCarga)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_CargaCombustible_ObtenerPorId>("dbo.sp_CargaCombustible_ObtenerPorId",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdCarga = IdCarga
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

