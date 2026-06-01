using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Transporte_Web_Service.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Transporte_Web_Service.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Transporte_Web_Service.Data
{
    public class RutasDAL
    {
        private readonly MiDbContext _context;

        public RutasDAL(MiDbContext context)
        {
            _context = context;
        }
        public List<RespuestaGeneral> Dal_Ruta_Desactivar(int IdRuta, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRuta = new SqlParameter("@IdRuta", (object)IdRuta);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdRuta, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Ruta_Desactivar @IdRuta, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_Ruta_Guardar(int IdRuta, int IdEmpresa, int IdSucursal, string Nombre, string Origen, string Destino, decimal DistanciaKm, int TiempoEstimadoMin, byte Activo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRuta = new SqlParameter("@IdRuta", (object)IdRuta);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _Nombre = new SqlParameter("@Nombre", (object)Nombre);
                var _Origen = new SqlParameter("@Origen", (object)Origen);
                var _Destino = new SqlParameter("@Destino", (object)Destino);
                var _DistanciaKm = new SqlParameter("@DistanciaKm", (object)DistanciaKm);
                var _TiempoEstimadoMin = new SqlParameter("@TiempoEstimadoMin", (object)TiempoEstimadoMin);
                var _Activo = new SqlParameter("@Activo", (object)Activo);

                object[] parametros = new object[] { _IdRuta, _IdEmpresa, _IdSucursal, _Nombre, _Origen, _Destino, _DistanciaKm, _TiempoEstimadoMin, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Ruta_Guardar @IdRuta, @IdEmpresa, @IdSucursal, @Nombre, @Origen, @Destino, @DistanciaKm, @TiempoEstimadoMin, @Activo", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_Ruta_Listar> Dal_Ruta_Listar(int IdEmpresa, int IdSucursal, byte SoloActivos, string TextoBusqueda)
        {
            List<Ent_Ruta_Listar> listaDatos = new List<Ent_Ruta_Listar>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)SoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)TextoBusqueda);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Ent_Ruta_Listar>()
                             .FromSqlRaw("EXEC sp_Ruta_Listar @IdEmpresa, @IdSucursal, @SoloActivos, @TextoBusqueda", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_Ruta_Listar> Dal_Ruta_ObtenerPorId(int IdRuta, int IdEmpresa)
        {
            List<Ent_Ruta_Listar> listaDatos = new List<Ent_Ruta_Listar>();
            try
            {
                var _IdRuta = new SqlParameter("@IdRuta", (object)IdRuta);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdRuta, _IdEmpresa };

                listaDatos = _context.Set<Ent_Ruta_Listar>()
                             .FromSqlRaw("EXEC sp_Ruta_ObtenerPorId @IdRuta, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_RutaDetalle_Eliminar(int IdRutaDetalle, int IdRuta)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRutaDetalle = new SqlParameter("@IdRutaDetalle", (object)IdRutaDetalle);
                var _IdRuta = new SqlParameter("@IdRuta", (object)IdRuta);

                object[] parametros = new object[] { _IdRutaDetalle, _IdRuta };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_RutaDetalle_Eliminar @IdRutaDetalle, @IdRuta", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_RutaDetalle_Guardar(int IdRutaDetalle, int IdRuta, int Orden, string Punto, decimal Latitud, decimal Longitud, string Tipo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRutaDetalle = new SqlParameter("@IdRutaDetalle", (object)IdRutaDetalle);
                var _IdRuta = new SqlParameter("@IdRuta", (object)IdRuta);
                var _Orden = new SqlParameter("@Orden", (object)Orden);
                var _Punto = new SqlParameter("@Punto", (object)Punto);
                var _Latitud = new SqlParameter("@Latitud", (object)Latitud);
                var _Longitud = new SqlParameter("@Longitud", (object)Longitud);
                var _Tipo = new SqlParameter("@Tipo", (object)Tipo);

                object[] parametros = new object[] { _IdRutaDetalle, _IdRuta, _Orden, _Punto, _Latitud, _Longitud, _Tipo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_RutaDetalle_Guardar @IdRutaDetalle, @IdRuta, @Orden, @Punto, @Latitud, @Longitud, @Tipo", parametros)
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


