using Humanizer;
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
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class DashboardDAL
    {
        private readonly MiDbContext _context;

        public DashboardDAL(MiDbContext context)
        {
            _context = context;

        }

        public List<Entity_Dashboard_CostosPorTipo> Dal_dashObtenCostoTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Entity_Dashboard_CostosPorTipo> listaDatos = new List<Entity_Dashboard_CostosPorTipo>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };

                listaDatos = _context.Set<Entity_Dashboard_CostosPorTipo>()
                            .FromSqlRaw("EXEC sp_Dashboard_CostosPorTipo @IdEmpresa, @IdSucursal, @FechaInicio, @FechaFin", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();
            }    
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Entity_Dashboard_ResumenOperativo> Dal_Dashboard_ResumenOperativo_TraeDatos(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        { 
            List<Entity_Dashboard_ResumenOperativo> listaDatos = new List<Entity_Dashboard_ResumenOperativo>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);
                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };
                listaDatos = _context.Set<Entity_Dashboard_ResumenOperativo>()
                                .FromSqlRaw("EXEC sp_Dashboard_ResumenOperativo @IdEmpresa, @IdSucursal,@FechaInicio, @FechaFin ", parametros)
                                .AsNoTracking() // Agrega esto para consultas de solo lectura
                                .ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Entity_Dashboard_RentabilidadMensual> Dal_dashRentaBilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
        {   
            List<Entity_Dashboard_RentabilidadMensual> listaDatos = new List<Entity_Dashboard_RentabilidadMensual>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _Anio = new SqlParameter("@Anio", (object)Anio);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _Anio };

                listaDatos = _context.Set<Entity_Dashboard_RentabilidadMensual>()
                                .FromSqlRaw("EXEC sp_Dashboard_RentabilidadMensual  @IdEmpresa, @IdSucursal,@Anio ", parametros)
                                .AsNoTracking() // Agrega esto para consultas de solo lectura
                                .ToList();  
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Entity_Dashboard_TopClientes> Dal_dashDashboardTopClientes(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Entity_Dashboard_TopClientes> listaDatos = new List<Entity_Dashboard_TopClientes>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);
                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };
                listaDatos = _context.Set<Entity_Dashboard_TopClientes>()
                                .FromSqlRaw("EXEC sp_Dashboard_TopClientes  @IdEmpresa, @IdSucursal,@FechaInicio, @FechaFin ", parametros)
                                .AsNoTracking() // Agrega esto para consultas de solo lectura
                                .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Entity_Dashboard_ViajesPorEstado> Dal_dashObtenViajeEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Entity_Dashboard_ViajesPorEstado> listaDatos = new List<Entity_Dashboard_ViajesPorEstado>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };

                listaDatos = _context.Set<Entity_Dashboard_ViajesPorEstado>()
                                .FromSqlRaw("EXEC sp_Dashboard_ViajesPorEstado  @IdEmpresa, @IdSucursal,@FechaInicio, @FechaFin ", parametros)
                                .AsNoTracking() // Agrega esto para consultas de solo lectura
                                .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}
    
