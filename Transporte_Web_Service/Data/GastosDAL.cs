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
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class GastosDAL
    {
        private readonly MiDbContext _context;

        public GastosDAL(MiDbContext context)
        {
            _context = context;
        }
        public List<RespuestaGeneral> Dal_Gasto_Eliminar(int IdGasto, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdGasto = new SqlParameter("@IdGasto", (object)IdGasto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdGasto, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Gasto_Eliminar @IdGasto, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_Gasto_Guardar(int IdGasto, int IdEmpresa, int IdSucursal, int IdTipoGasto, int IdViaje, int IdUnidad, string Fecha, decimal Monto, string Referencia, string Descripcion, byte EsFacturable)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdGasto = new SqlParameter("@IdGasto", (object)IdGasto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdTipoGasto = new SqlParameter("@IdTipoGasto", (object)IdTipoGasto);
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);
                var _IdUnidad = new SqlParameter("@IdUnidad", (object)IdUnidad);
                var _Fecha = new SqlParameter("@Fecha", (object)Fecha);
                var _Monto = new SqlParameter("@Monto", (object)Monto);
                var _Referencia = new SqlParameter("@Referencia", (object)Referencia);
                var _Descripcion = new SqlParameter("@Descripcion", (object)Descripcion);
                var _EsFacturable = new SqlParameter("@EsFacturable", (object)EsFacturable);

                object[] parametros = new object[] { _IdGasto, _IdEmpresa, _IdSucursal, _IdTipoGasto, _IdViaje, _IdUnidad, _Fecha, _Monto, _Referencia, _Descripcion, _EsFacturable };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Gasto_Guardar @IdGasto, @IdEmpresa, @IdSucursal, @IdTipoGasto, @IdViaje, @IdUnidad, @Fecha, @Monto, @Referencia, @Descripcion, @EsFacturable ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_Gasto_ListarPorViaje> Dal_Gasto_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            List<Ent_Gasto_ListarPorViaje> listaDatos = new List<Ent_Gasto_ListarPorViaje>();
            try
            {
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdViaje, _IdEmpresa };

                listaDatos = _context.Set<Ent_Gasto_ListarPorViaje>()
                             .FromSqlRaw("EXEC sp_Gasto_ListarPorViaje @IdViaje, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_Gasto_ObtenerPorId> Dal_Gasto_ObtenerPorId(int IdGasto, int IdEmpresa)
        {
            List<Ent_Gasto_ObtenerPorId> listaDatos = new List<Ent_Gasto_ObtenerPorId>();
            try
            {
                var _IdGasto = new SqlParameter("@IdGasto", (object)IdGasto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdGasto, _IdEmpresa };

                listaDatos = _context.Set<Ent_Gasto_ObtenerPorId>()
                             .FromSqlRaw("EXEC sp_Gasto_ObtenerPorId @IdGasto, @IdEmpresa ", parametros)
                             .AsNoTracking()
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


