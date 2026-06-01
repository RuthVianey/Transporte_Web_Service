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
    public class UnidadesDAL
    {
        private readonly MiDbContext _context;

        public UnidadesDAL(MiDbContext context)
        {
            _context = context;
        }
        public List<RespuestaGeneral> Dal_TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdTipoUnidad = new SqlParameter("@IdTipoUnidad", (object)IdTipoUnidad);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdTipoUnidad, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_TipoUnidad_Desactivar @IdTipoUnidad, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdTipoUnidad = new SqlParameter("@IdTipoUnidad", (object)IdTipoUnidad);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _Descripcion = new SqlParameter("@Descripcion", (object)Descripcion);
                var _Activo = new SqlParameter("@Activo", (object)Activo);

                object[] parametros = new object[] { _IdTipoUnidad, _IdEmpresa, _Descripcion, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_TipoUnidad_Guardar @IdTipoUnidad, @IdEmpresa, @Descripcion, @Activo ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_TipoUnidad_Listar> Dal_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            List<Ent_TipoUnidad_Listar> listaDatos = new List<Ent_TipoUnidad_Listar>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)SoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)TextoBusqueda);

                object[] parametros = new object[] { _IdEmpresa, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Ent_TipoUnidad_Listar>()
                             .FromSqlRaw("EXEC sp_TipoUnidad_Listar @IdEmpresa, @SoloActivos, @TextoBusqueda ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdTipoUnidad = new SqlParameter("@IdTipoUnidad", (object)IdTipoUnidad);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdTipoUnidad, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_TipoUnidad_ObtenerPorId @IdTipoUnidad, @IdEmpresa ", parametros)
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
