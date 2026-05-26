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


        public List<Dashboard_CostosPorTipo> dashObtenCostoTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Dashboard_CostosPorTipo> listaDatos = new List<Dashboard_CostosPorTipo>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };

                listaDatos = _context.Set<Dashboard_CostosPorTipo>().FromSqlRaw("EXEC sp_Dashboard_CostosPorTipo  @IdEmpresa, @IdSucursal,@FechaInicio, @FechaFin ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Dasboard_RentabilidadMensual> dashRentaBilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
        {
            List<Dasboard_RentabilidadMensual> listaDatos = new List<Dasboard_RentabilidadMensual>();

            try 
            { 
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _Anio = new SqlParameter("@Anio", (object)Anio);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _Anio };

                listaDatos = _context.Set<Dasboard_RentabilidadMensual>().FromSqlRaw("EXEC sp_Dashboard_RentabilidadMensual  @IdEmpresa, @IdSucursal,@Anio ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Dashboard_ViajesPorEstado> dashObtenViajeEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Dashboard_ViajesPorEstado> listaDatos = new List<Dashboard_ViajesPorEstado>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _FechaInicio = new SqlParameter("@FechaInicio", (object)FechaInicio);
                var _FechaFin = new SqlParameter("@FechaFin", (object)FechaFin);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _FechaInicio, _FechaFin };

                listaDatos = _context.Set<Dashboard_ViajesPorEstado>().FromSqlRaw("EXEC sp_Dashboard_ViajesPorEstado  @IdEmpresa, @IdSucursal,@FechaInicio, @FechaFin ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}
    
