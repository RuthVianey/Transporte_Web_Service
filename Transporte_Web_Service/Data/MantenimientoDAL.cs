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
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class MantenimientoDAL
    {
        private readonly MiDbContext _context;

        public MantenimientoDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_Mantenimiento_Eliminar(int IdMantenimiento, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdMantenimiento, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Mantenimiento_Eliminar @IdMantenimiento, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_Mantenimiento_Guardar(int IdMantenimiento, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, int IdTipoMantenimiento, string Fecha, decimal KmUnidad, string Descripcion, decimal Costo, byte EsAsignableAViaje)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdUnidad = new SqlParameter("@IdUnidad", (object)IdUnidad);
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);
                var _IdTipoMantenimiento = new SqlParameter("@IdTipoMantenimiento", (object)IdTipoMantenimiento);
                var _Fecha = new SqlParameter("@Fecha", (object)Fecha);
                var _KmUnidad = new SqlParameter("@KmUnidad", (object)KmUnidad);
                var _Descripcion = new SqlParameter("@Descripcion", (object)Descripcion);
                var _Costo = new SqlParameter("@Costo", (object)Costo);
                var _EsAsignableAViaje = new SqlParameter("@EsAsignableAViaje", (object)EsAsignableAViaje);



                object[] parametros = new object[] { _IdMantenimiento, _IdEmpresa, _IdSucursal, _IdUnidad, _IdViaje, _IdTipoMantenimiento, _Fecha, _KmUnidad, _Descripcion, _Costo, _EsAsignableAViaje };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Mantenimiento_Guardar @IdMantenimiento, @IdEmpresa, @IdSucursal, @IdUnidad, @IdViaje, @IdTipoMantenimiento, @Fecha, @KmUnidad, @Descripcion, @Costo, @EsAsignableAViaje", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Mantenimiento_ListarPorViaje> Dal_Mantenimiento_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            List<Ent_Mantenimiento_ListarPorViaje> listaDatos = new List<Ent_Mantenimiento_ListarPorViaje>();
            try
            {
                var _IdViaje = new SqlParameter("@IdViaje", (object)IdViaje);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                
                object[] parametros = new object[] { _IdViaje, _IdEmpresa };

                listaDatos = _context.Set<Ent_Mantenimiento_ListarPorViaje>()
                             .FromSqlRaw("EXEC sp_Mantenimiento_ListarPorViaje @IdViaje, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Mantenimiento_ObtenerPorId> Dal_Mantenimiento_ObtenerPorId(int IdMantenimiento, int IdEmpresa)
        {
            List<Ent_Mantenimiento_ObtenerPorId> listaDatos = new List<Ent_Mantenimiento_ObtenerPorId>();
            try
            {
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                
                object[] parametros = new object[] { _IdMantenimiento, _IdEmpresa };

                listaDatos = _context.Set<Ent_Mantenimiento_ObtenerPorId>()
                             .FromSqlRaw("EXEC sp_Mantenimiento_ObtenerPorId @IdMantenimiento, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_MantenimientoConcepto_Desactivar(int IdConcepto, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdConcepto = new SqlParameter("@IdConcepto", (object)IdConcepto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdConcepto, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_MantenimientoConcepto_Desactivar @IdConcepto, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_MantenimientoConcepto_Guardar(int IdConcepto, int IdEmpresa, string Descripcion, byte Activo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdConcepto = new SqlParameter("@IdConcepto", (object)IdConcepto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _Descripcion = new SqlParameter("@Descripcion", (object)Descripcion);
                var _Activo = new SqlParameter("@Activo", (object)Activo);

                object[] parametros = new object[] { _IdConcepto, _IdEmpresa, _Descripcion, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_MantenimientoConcepto_Guardar @IdConcepto, @IdEmpresa, @Descripcion, @Activo", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_MantenimientoConcepto_ObtenerPorId> Dal_MantenimientoConcepto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            List<Ent_MantenimientoConcepto_ObtenerPorId> listaDatos = new List<Ent_MantenimientoConcepto_ObtenerPorId>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)SoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)TextoBusqueda);
                

                object[] parametros = new object[] { _IdEmpresa, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Ent_MantenimientoConcepto_ObtenerPorId>()
                             .FromSqlRaw("EXEC sp_MantenimientoConcepto_Listar @IdEmpresa, @SoloActivos, @TextoBusqueda", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_MantenimientoConcepto_ObtenerPorId> Dal_MantenimientoConcepto_ObtenerPorId(int IdConcepto, int IdEmpresa)
        {
            List<Ent_MantenimientoConcepto_ObtenerPorId> listaDatos = new List<Ent_MantenimientoConcepto_ObtenerPorId>();
            try
            {
                var _IdConcepto = new SqlParameter("@IdConcepto", (object)IdConcepto);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdConcepto, _IdEmpresa };

                listaDatos = _context.Set<Ent_MantenimientoConcepto_ObtenerPorId>()
                             .FromSqlRaw("EXEC sp_MantenimientoConcepto_ObtenerPorId @IdConcepto, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_MantenimientoDetalle_Eliminar(int IdDetalle, int IdMantenimiento)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdDetalle = new SqlParameter("@IdDetalle", (object)IdDetalle);
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);

                object[] parametros = new object[] { _IdDetalle, _IdMantenimiento };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_MantenimientoDetalle_Eliminar @IdDetalle, @IdMantenimiento", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_MantenimientoDetalle_Guardar(int IdDetalle, int IdMantenimiento, int IdConcepto, decimal Cantidad, decimal CostoUnitario)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdDetalle = new SqlParameter("@IdDetalle", (object)IdDetalle);
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);
                var _IdConcepto = new SqlParameter("@IdConcepto", (object)IdConcepto);
                var _Cantidad = new SqlParameter("@Cantidad", (object)Cantidad);
                var _CostoUnitario = new SqlParameter("@CostoUnitario", (object)CostoUnitario);

                object[] parametros = new object[] { _IdDetalle, _IdMantenimiento, _IdConcepto, _Cantidad, _CostoUnitario };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_MantenimientoDetalle_Guardar @IdDetalle, @IdMantenimiento, @IdConcepto, @Cantidad, @CostoUnitario", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_MantenimientoDetalle_Listar> Dal_MantenimientoDetalle_Listar(int IdMantenimiento)
        {
            List<Ent_MantenimientoDetalle_Listar> listaDatos = new List<Ent_MantenimientoDetalle_Listar>();
            try
            {
                var _IdMantenimiento = new SqlParameter("@IdMantenimiento", (object)IdMantenimiento);

                object[] parametros = new object[] { _IdMantenimiento };

                listaDatos = _context.Set<Ent_MantenimientoDetalle_Listar>()
                             .FromSqlRaw("EXEC sp_MantenimientoDetalle_Listar @IdMantenimiento", parametros)
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


