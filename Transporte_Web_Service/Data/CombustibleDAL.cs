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
    public class CombustibleDAL
    {
        private readonly MiDbContext _context;

        public CombustibleDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_CargaCombustible_Eliminar(int IdCarga, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();

            try
            {
                var _IdCarga = new SqlParameter("@IdCarga", (object)IdCarga);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                
                object[] parametros = new object[] { _IdCarga, _IdEmpresa };
                listaDatos = _context.Set<RespuestaGeneral>().
                            FromSqlRaw("EXEC sp_CargaCombustible_Eliminar @IdCarga, @IdEmpresa ", parametros)
                            .AsNoTracking()
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_CargaCombustible_Guardar(int IdCarga, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, string Fecha, decimal Litros, decimal PrecioLitro, decimal Km, decimal Odometro, decimal RendimientoKmPorLitro, string Referencia)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();

            try
            {
                var _IdCarga = new SqlParameter("@IdCarga", (object)IdCarga);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdUnidad = new SqlParameter("@IdUnidad", (object)IdUnidad);
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);
                var _Fecha = new SqlParameter("@Fecha", (object)Fecha);
                var _Litros = new SqlParameter("@Litros", (object)Litros);
                var _PrecioLitro = new SqlParameter("@PrecioLitro", (object)PrecioLitro);
                var _Km = new SqlParameter("@Km", (object)Km);
                var _Odometro = new SqlParameter("@Odometro", (object)Odometro);
                var _RendimientoKmPorLitro = new SqlParameter("@RendimientoKmPorLitro", (object)RendimientoKmPorLitro);
                var _Referencia = new SqlParameter("@Referencia", (object)Referencia);


                object[] parametros = new object[] { _IdCarga, _IdEmpresa, _IdSucursal, _IdUnidad, _IdViaje, _Fecha, _Litros, _PrecioLitro, _Km, _Odometro, _RendimientoKmPorLitro, _Referencia };
                listaDatos = _context.Set<RespuestaGeneral>().
                            FromSqlRaw("EXEC sp_CargaCombustible_Guardar @IdCarga, @IdEmpresa, @IdSucursal, @IdUnidad, @IdViaje, @Fecha, @Litros, @PrecioLitro, @Km, @Odometro, @RendimientoKmPorLitro, @Referencia ", parametros)
                            .AsNoTracking()
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_CargaCombustible_ListarPorViaje> Dal_CargaCombustible_ListarPorViaje(int IdEmpresa, int IdViaje)
        {
            List<Ent_CargaCombustible_ListarPorViaje> listaDatos = new List<Ent_CargaCombustible_ListarPorViaje>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);

                object[] parametros = new object[] { _IdEmpresa, _IdViaje };
                listaDatos = _context.Set<Ent_CargaCombustible_ListarPorViaje>().
                            FromSqlRaw("EXEC sp_CargaCombustible_ListarPorViaje @IdViaje, @IdEmpresa ", parametros)
                            .AsNoTracking()
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_CargaCombustible_ObtenerPorId> Dal_CargaCombustible_ObtenerPorId(int IdEmpresa, int IdCarga)
        {
            List<Ent_CargaCombustible_ObtenerPorId> listaDatos = new List<Ent_CargaCombustible_ObtenerPorId>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdCarga = new SqlParameter("@IdCarga", (object)IdCarga);

                object[] parametros = new object[] { _IdEmpresa, _IdCarga };
                listaDatos = _context.Set<Ent_CargaCombustible_ObtenerPorId>().
                            FromSqlRaw("EXEC sp_CargaCombustible_ObtenerPorId @IdCarga, @IdEmpresa ", parametros)
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

