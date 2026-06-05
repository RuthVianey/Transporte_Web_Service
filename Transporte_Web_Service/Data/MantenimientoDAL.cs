using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
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
    public class MantenimientoDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public MantenimientoDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Mantenimiento_Eliminar(int IdMantenimiento, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Mantenimiento_Eliminar",
                new
                {
                    IdMantenimiento = IdMantenimiento,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Mantenimiento_Guardar(int IdMantenimiento, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, int IdTipoMantenimiento, string Fecha, decimal KmUnidad, string Descripcion, decimal Costo, byte EsAsignableAViaje)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Mantenimiento_Guardar",
                new
                {
                    IdMantenimiento = IdMantenimiento,
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    IdUnidad = IdUnidad,
                    IdViaje = IdViaje,
                    IdTipoMantenimiento = IdTipoMantenimiento,
                    Fecha = Fecha,
                    KmUnidad = KmUnidad,
                    Descripcion = Descripcion,
                    Costo = Costo,
                    EsAsignableAViaje = EsAsignableAViaje
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Mantenimiento_ListarPorViaje?>> Dal_Mantenimiento_ListarPorViaje(int IdViaje, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Mantenimiento_ListarPorViaje?>("dbo.sp_Mantenimiento_ListarPorViaje",
                new
                {
                    IdViaje = IdViaje,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Mantenimiento_ObtenerPorId?>> Dal_Mantenimiento_ObtenerPorId(int IdMantenimiento, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Mantenimiento_ObtenerPorId?>("dbo.sp_Mantenimiento_ObtenerPorId",
                new
                {
                    IdMantenimiento = IdMantenimiento,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_MantenimientoConcepto_Desactivar(int IdConcepto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_MantenimientoConcepto_Desactivar",
                new
                {
                    IdConcepto = IdConcepto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_MantenimientoConcepto_Guardar(int IdConcepto, int IdEmpresa, string Descripcion, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_MantenimientoConcepto_Guardar",
                new
                {
                    IdConcepto = IdConcepto,
                    IdEmpresa = IdEmpresa,
                    Descripcion = Descripcion,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>> Dal_MantenimientoConcepto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_MantenimientoConcepto_ObtenerPorId?>("dbo.sp_MantenimientoConcepto_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>> Dal_MantenimientoConcepto_ObtenerPorId(int IdConcepto, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_MantenimientoConcepto_ObtenerPorId?>("dbo.sp_MantenimientoConcepto_ObtenerPorId",
                new
                {
                    IdConcepto = IdConcepto,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_MantenimientoDetalle_Eliminar(int IdDetalle, int IdMantenimiento)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_MantenimientoDetalle_Eliminar",
                new
                {
                    IdDetalle = IdDetalle,
                    IdMantenimiento = IdMantenimiento
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_MantenimientoDetalle_Guardar(int IdDetalle, int IdMantenimiento, int IdConcepto, decimal Cantidad, decimal CostoUnitario)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_MantenimientoDetalle_Guardar",
                new
                {
                    IdDetalle = IdDetalle,
                    IdMantenimiento = IdMantenimiento,
                    IdConcepto = IdConcepto,
                    Cantidad = Cantidad,
                    CostoUnitario = CostoUnitario
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_MantenimientoDetalle_Listar?>> Dal_MantenimientoDetalle_Listar(int IdMantenimiento)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_MantenimientoDetalle_Listar?>("dbo.sp_MantenimientoDetalle_Listar",
                new
                {
                    IdMantenimiento = IdMantenimiento
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoMantenimiento_Desactivar(int IdTipoMantenimiento, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoMantenimiento_Desactivar",
                new
                {
                    IdTipoMantenimiento = IdTipoMantenimiento,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoMantenimiento_Guardar(int IdTipoMantenimiento, int IdEmpresa, string Descripcion, byte EsPreventivo, byte EsCorrectivo, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoMantenimiento_Guardar",
                new
                {
                    IdTipoMantenimiento = IdTipoMantenimiento,
                    IdEmpresa = IdEmpresa,
                    Descripcion = Descripcion,
                    EsPreventivo = EsPreventivo,
                    EsCorrectivo = EsCorrectivo,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_TipoMantenimiento_Listar?>> Dal_TipoMantenimiento_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_TipoMantenimiento_Listar?>("dbo.sp_TipoMantenimiento_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_TipoMantenimiento_Listar?>> Dal_TipoMantenimiento_ObtenerPorId(int IdTipoMantenimiento, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_TipoMantenimiento_Listar?>("dbo.sp_TipoMantenimiento_ObtenerPorId",
                new
                {
                    IdTipoMantenimiento = IdTipoMantenimiento,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}


