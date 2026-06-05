using Dapper;
using Humanizer;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class DashboardDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;   

        public DashboardDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<IEnumerable<Entity_Dashboard_CostosPorTipo?>> Dal_DashObtenCostoTipo(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_CostosPorTipo?>("dbo.sp_Dashboard_CostosPorTipo",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    FechaInicio = FechaInicio,
                    FechaFin = FechaFin
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<IEnumerable<Entity_Dashboard_ResumenOperativo?>> Dal_Dashboard_ResumenOperativo(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_ResumenOperativo?>("dbo.sp_Dashboard_ResumenOperativo",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    FechaInicio = FechaInicio,
                    FechaFin = FechaFin
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_Dashboard_RentabilidadMensual?>> Dal_Dashboard_RentabilidadMensual(int IdEmpresa, int? IdSucursal, int Anio)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_RentabilidadMensual?>("dbo.sp_Dashboard_RentabilidadMensual",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    Anio = Anio
                    
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_Dashboard_TopClientes?>> Dal_Dashboard_TopClientes(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_TopClientes?>("dbo.sp_Dashboard_TopClientes",
               new
               {
                   IdEmpresa = IdEmpresa,
                   IdSucursal = IdSucursal,
                   FechaInicio = FechaInicio,
                   FechaFin = FechaFin
               },
               commandType: CommandType.StoredProcedure
           );
        }

        public async Task<IEnumerable<Entity_Dashboard_TopUnidades?>> Dal_dashDashboardTopUnidades(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_TopUnidades?>("dbo.sp_Dashboard_TopUnidades",
               new
               {
                   IdEmpresa = IdEmpresa,
                   IdSucursal = IdSucursal,
                   FechaInicio = FechaInicio,
                   FechaFin = FechaFin
               },
               commandType: CommandType.StoredProcedure
           );
        }

        public async Task<IEnumerable<Entity_Dashboard_ViajesPorEstado>> Dal_dashObtenViajeEstado(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Dashboard_ViajesPorEstado>( "dbo.sp_Dashboard_ViajesPorEstado",
                new
                {
                    IdEmpresa,
                    IdSucursal,
                    FechaInicio,
                    FechaFin
                },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
    
