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
    public class ViajesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        //public ViajesDAL(DbConnectionFactory connectionFactory)
        public ViajesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_EstadoViaje_Guardar",
                new
                {
                    IdEstadoViaje = IdEstadoViaje,
                    Descripcion = Descripcion
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_EstadoViaje_Listar?>> Dal_EstadoViaje_Listar()
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_EstadoViaje_Listar?>("dbo.sp_EstadoViaje_Listar",
                new
                {
                     
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_EstadoViaje_Listar?>> Dal_EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_EstadoViaje_Listar?>("dbo.sp_EstadoViaje_ObtenerPorId",
                new
                {
                    IdEstadoViaje = IdEstadoViaje
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Viaje_Listar?>> Dal_Viaje_Listar(int IdEmpresa, int? IdSucursal, int? IdCliente, int? IdOperador, int? IdEstadoViaje, DateTime? FechaInicio, DateTime? FechaFin, string? TextoBusqueda)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Viaje_Listar?>("dbo.sp_Viaje_Listar",
                new { IdEmpresa, IdSucursal, IdCliente, IdOperador, IdEstadoViaje, FechaInicio, FechaFin, TextoBusqueda },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Viaje_Listar?>> Dal_Viaje_ObtenerPorId(int IdViaje, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Viaje_Listar?>("dbo.sp_Viaje_ObtenerPorId",
                new { IdViaje, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Viaje_Guardar(int? IdViaje, int IdEmpresa, int? IdSucursal, int? IdOperador, int IdCliente, int? IdRuta, int IdEstadoViaje, string? Remision, DateTime? FechaSalida, DateTime? FechaLlegadaEstimada, DateTime? FechaLlegadaReal, string? Origen, string? Destino, decimal? KmInicial, decimal? KmFinal, decimal Ingreso, decimal? PrecioPactado, string? Observaciones)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Viaje_Guardar",
                new { IdViaje, IdEmpresa, IdSucursal, IdOperador, IdCliente, IdRuta, IdEstadoViaje, Remision, FechaSalida, FechaLlegadaEstimada, FechaLlegadaReal, Origen, Destino, KmInicial, KmFinal, Ingreso, PrecioPactado, Observaciones },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeMovimiento_Guardar(int? IdViajeMovimiento, int IdEmpresa, int? IdSucursal, int IdViaje, string TipoMovimiento, int? Secuencia, DateTime? FechaMovimiento, string? Lugar, string? ClienteDestino, int? IdProducto, string? Producto, decimal Cantidad, string? UnidadMedida, decimal? Temperatura, decimal? Densidad, string? Referencia, string? Observaciones, int? IdUsuarioRegistro)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeMovimiento_Guardar",
                new { IdViajeMovimiento, IdEmpresa, IdSucursal, IdViaje, TipoMovimiento, Secuencia, FechaMovimiento, Lugar, ClienteDestino, IdProducto, Producto, Cantidad, UnidadMedida, Temperatura, Densidad, Referencia, Observaciones, IdUsuarioRegistro },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_ViajeMovimiento_Listar?>> Dal_ViajeMovimiento_ListarPorViaje(int IdViaje, int IdEmpresa, string? TipoMovimiento, bool SoloActivos)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_ViajeMovimiento_Listar?>("dbo.sp_ViajeMovimiento_ListarPorViaje",
                new { IdViaje, IdEmpresa, TipoMovimiento, SoloActivos },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeMovimiento_Eliminar(int IdViajeMovimiento, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeMovimiento_Eliminar",
                new { IdViajeMovimiento, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_ViajeUnidad_Listar?>> Dal_ViajeUnidad_Listar(int IdViaje, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_ViajeUnidad_Listar?>("dbo.sp_ViajeUnidad_Listar",
                new { IdViaje, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeUnidad_Asignar(int IdViaje, int IdEmpresa, int IdUnidad, string? TipoParticipacion)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeUnidad_Asignar",
                new { IdViaje, IdEmpresa, IdUnidad, TipoParticipacion },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeUnidad_Quitar(int IdViajeUnidad, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeUnidad_Quitar",
                new { IdViajeUnidad, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Viaje_Cerrar(int IdViaje, int IdEmpresa, int IdEstadoViaje, DateTime FechaLlegadaReal, decimal KmFinal, decimal? Ingreso, string? Observaciones)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Viaje_Cerrar",
                new { IdViaje, IdEmpresa, IdEstadoViaje, FechaLlegadaReal, KmFinal, Ingreso, Observaciones },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_ValidacionCierre>> Dal_Viaje_CierreValidar(int IdViaje, int IdEmpresa, DateTime? FechaLlegadaReal, decimal? KmFinal)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var resultados = await connection.QueryMultipleAsync("dbo.sp_Viaje_CierreValidar",
                new { IdViaje, IdEmpresa, FechaLlegadaReal, KmFinal }, commandType: CommandType.StoredProcedure);
            var reglasBase = await resultados.ReadAsync<Entity_ValidacionCierre>();
            var documentosRequeridos = await resultados.ReadAsync<Entity_ValidacionCierre>();
            return reglasBase.Concat(documentosRequeridos);
        }
    }
}


