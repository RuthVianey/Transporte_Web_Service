using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Data
{
    public class SeguridadDAL
    {
        private readonly MiDbContext _context;

        public SeguridadDAL(MiDbContext context)
        {
            _context = context;
        }
        public List<RespuestaGeneral> Dal_Sucursal_Desactivar(int IdSucursal, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdSucursal, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Sucursal_Desactivar @IdSucursal, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Dal_Sucursal_Guardar(int IdSucursal, int IdEmpresa, string Nombre, string NombreCorto, string Codigo, string Calle, string Colonia, string Municipio, string Estado, string CodigoPostal, string Telefono, byte Activo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _Nombre = new SqlParameter("@Nombre", (object)Nombre);
                var _NombreCorto = new SqlParameter("@NombreCorto", (object)NombreCorto);
                var _Codigo = new SqlParameter("@Codigo", (object)Codigo);
                var _Calle = new SqlParameter("@Calle", (object)Calle);
                var _Colonia = new SqlParameter("@Colonia", (object)Colonia);
                var _Municipio = new SqlParameter("@Municipio", (object)Municipio);
                var _Estado = new SqlParameter("@Estado", (object)Estado);
                var _CodigoPostal = new SqlParameter("@CodigoPostal", (object)CodigoPostal);
                var _Telefono = new SqlParameter("@Telefono", (object)Telefono);
                var _Activo = new SqlParameter("@Activo", (object)Activo);

                object[] parametros = new object[] { _IdSucursal, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Sucursal_Guardar @IdSucursal, @IdEmpresa, @Nombre, @NombreCorto, @Codigo, @Calle, @Colonia, @Municipio, @Estado, @CodigoPostal, @Telefono, @Activo", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Sucursal_Listar> Dal_Sucursal_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            List<Sucursal_Listar> listaDatos = new List<Sucursal_Listar>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)SoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)TextoBusqueda);

                object[] parametros = new object[] { _IdEmpresa, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Sucursal_Listar>()
                             .FromSqlRaw("EXEC sp_Sucursal_Listar @IdEmpresa, @SoloActivos, @TextoBusqueda", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Sucursal_Listar> Dal_Sucursal_ObtenerPorId(int IdSucursal, int IdEmpresa)
        {
            List<Sucursal_Listar> listaDatos = new List<Sucursal_Listar>();
            try
            {
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)IdSucursal);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdSucursal, _IdEmpresa };

                listaDatos = _context.Set<Sucursal_Listar>()
                             .FromSqlRaw("EXEC sp_Sucursal_ObtenerPorId @IdSucursal, @IdEmpresa", parametros)
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


