using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public class RolesDAL
    {
        private readonly MiDbContext _context;

        public RolesDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_Rol_Desactivar(int IdRol, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRol = new SqlParameter("@IdRol", (object)IdRol);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdRol, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Rol_Desactivar @IdRol, @IdEmpresa", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_Rol_Guardar(int IdRol, int IdEmpresa, string Nombre, byte Activo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRol = new SqlParameter("@IdRol", (object)IdRol);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _Nombre = new SqlParameter("@Nombre", (object)Nombre);
                var _Activo = new SqlParameter("@Activo", (object)Activo);

                object[] parametros = new object[] { _IdRol, _IdEmpresa, _Nombre, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Rol_Guardar @IdRol, @IdEmpresa, @Nombre, @Activo ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Listar_Roles> Dal_Rol_Listar(int IdEmpresa, byte SoloActivos)
        {
            List<Ent_Listar_Roles> listaDatos = new List<Ent_Listar_Roles>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)SoloActivos);

                object[] parametros = new object[] { _IdEmpresa, _SoloActivos };

                listaDatos = _context.Set<Ent_Listar_Roles>()
                             .FromSqlRaw("EXEC sp_Rol_Listar @IdEmpresa, @SoloActivos ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Listar_Roles> Dal_Rol_ObtenerPorId(int IdEmpresa, int IdRol)
        {
            List<Ent_Listar_Roles> listaDatos = new List<Ent_Listar_Roles>();
            try
            {
                var _IdRol = new SqlParameter("@IdRol", (object)IdRol);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdRol, _IdEmpresa };

                listaDatos = _context.Set<Ent_Listar_Roles>()
                             .FromSqlRaw("EXEC sp_Rol_ObtenerPorId @IdRol, @IdEmpresa ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_RolPrograma_GuardarPermiso(int IdRol, int IdEmpresa, int IdPrograma, byte PuedeLeer, byte PuedeEscribir, byte PuedeEliminar)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdRol = new SqlParameter("@IdRol", (object)IdRol);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                var _IdPrograma = new SqlParameter("@IdPrograma", (object)IdPrograma);
                var _PuedeLeer = new SqlParameter("@PuedeLeer", (object)PuedeLeer);
                var _PuedeEscribir = new SqlParameter("@PuedeEscribir", (object)PuedeEscribir);
                var _PuedeEliminar = new SqlParameter("@PuedeEliminar", (object)PuedeEliminar);

                object[] parametros = new object[] { _IdRol, _IdEmpresa, _IdPrograma, _PuedeLeer, _PuedeEscribir, _PuedeEliminar };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_RolPrograma_GuardarPermiso @IdRol, @IdEmpresa, @IdPrograma, @PuedeLeer, @PuedeEscribir, @PuedeEliminar ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_RolPrograma_ListarPorRol> Dal_RolPrograma_ListarPorRol(int IdEmpresa, int IdRol)
        {
            List<Ent_RolPrograma_ListarPorRol> listaDatos = new List<Ent_RolPrograma_ListarPorRol>();
            try
            {
                var _IdRol = new SqlParameter("@IdRol", (object)IdRol);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdRol, _IdEmpresa };

                listaDatos = _context.Set<Ent_RolPrograma_ListarPorRol>()
                             .FromSqlRaw("EXEC sp_RolPrograma_ListarPorRol @IdRol, @IdEmpresa ", parametros)
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
