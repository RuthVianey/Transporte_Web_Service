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
    public class RutasDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public RutasDAL(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<Entity_RespuestaGeneral?> Dal_Ruta_Desactivar(int IdRuta, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Ruta_Desactivar",
                new
                {
                    IdRuta = IdRuta,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_Ruta_Guardar(int IdRuta, int IdEmpresa, int IdSucursal, string Nombre, string Origen, string Destino, decimal DistanciaKm, int TiempoEstimadoMin, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Ruta_Guardar",
                new
                {
                    IdRuta = IdRuta,
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    Nombre = Nombre,
                    Origen = Origen,
                    Destino = Destino,
                    DistanciaKm = DistanciaKm,
                    TiempoEstimadoMin = TiempoEstimadoMin,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Ruta_Listar?> Dal_Ruta_Listar(int IdEmpresa, int IdSucursal, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Ruta_Listar>("dbo.sp_Ruta_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Ruta_Listar?> Dal_Ruta_ObtenerPorId(int IdRuta, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Ruta_Listar>("dbo.sp_Ruta_ObtenerPorId",
                new
                {
                    IdRuta = IdRuta,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_RutaDetalle_Eliminar(int IdRutaDetalle, int IdRuta)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_RutaDetalle_Eliminar",
                new
                {
                    IdRutaDetalle = IdRutaDetalle,
                    IdRuta = IdRuta
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_RutaDetalle_Guardar(int IdRutaDetalle, int IdRuta, int Orden, string Punto, decimal Latitud, decimal Longitud, string Tipo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_RutaDetalle_Guardar",
                new
                {
                    IdRutaDetalle = IdRutaDetalle,
                    IdRuta = IdRuta,
                    Orden = Orden,
                    Punto = Punto,
                    Latitud = Latitud,
                    Longitud = Longitud,
                    Tipo = Tipo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RutaDetalle_Listar?> Dal_RutaDetalle_Listar(int IdRuta)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RutaDetalle_Listar>("dbo.sp_RutaDetalle_Listar",
                new
                {
                    IdRuta = IdRuta
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RutaDetalle_Listar?> Dal_RutaDetalle_ObtenerPorId(int IdRutaDetalle, int IdRuta)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RutaDetalle_Listar>("dbo.sp_RutaDetalle_ObtenerPorId",
                new
                {
                    IdRutaDetalle = IdRutaDetalle,
                    IdRuta = IdRuta
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}


