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
    public class EmpresaDAL
    {
        private readonly MiDbContext _context;

        public EmpresaDAL(MiDbContext context)
        {
            _context = context;

        }
        public List<RespuestaGeneral> Dal_Empresa_Desactivar(int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();

            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);

                object[] parametros = new object[] { _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                            .FromSqlRaw("EXEC sp_Empresa_Desactivar @IdEmpresa", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", iIdEmpresa == null ? DBNull.Value : (object)iIdEmpresa);
                var _Nombre_Completo = new SqlParameter("@Nombre", sNombre == null ? DBNull.Value : (object)sNombre);
                var _Nombre_Corto = new SqlParameter("@NombreCorto", sNombre_Corto == null ? DBNull.Value : (object)sNombre_Corto);
                var _RFC = new SqlParameter("@RFC", sRFC == null ? DBNull.Value : (object)sRFC);
                var _Calle = new SqlParameter("@Calle", sCalle == null ? DBNull.Value : (object)sCalle);
                var _Colonia = new SqlParameter("@Colonia", sColonia == null ? DBNull.Value : (object)sColonia);
                var _Municipio = new SqlParameter("@Municipio", sMunicipio == null ? DBNull.Value : (object)sMunicipio);
                var _Estado = new SqlParameter("@Estado", sEstado == null ? DBNull.Value : (object)sEstado);
                var _Codigo_Postal = new SqlParameter("@CodigoPostal", sCodigo_Postal == null ? DBNull.Value : (object)sCodigo_Postal);
                var _Telefono = new SqlParameter("@Telefono", sTelefono == null ? DBNull.Value : (object)sTelefono);
                var _RutaLogo = new SqlParameter("@RutaLogo", sRutaLogo == null ? DBNull.Value : (object)sRutaLogo);
                var _Activo = new SqlParameter("@Activo", bActivo == null ? DBNull.Value : (object)bActivo);

                object[] parametros = new object[] { _IdEmpresa, _Nombre_Completo, _Nombre_Corto, _RFC, _Calle, _Colonia, _Municipio, _Estado, _Codigo_Postal, _Telefono, _RutaLogo, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>().
                             FromSqlRaw("EXEC sp_Empresa_Guardar @IdEmpresa, @Nombre, @NombreCorto, @RFC, @Calle, @Colonia, @Municipio, @Estado, @CodigoPostal, @Telefono, @RutaLogo, @Activo", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Empresa_Listar> Dal_Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            List<Empresa_Listar> listaDatos = new List<Empresa_Listar>();
            try
            {
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)bSoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)sTextoBusqueda);

                object[] parametros = new object[] { _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Empresa_Listar>()
                             .FromSqlRaw("EXEC sp_Empresa_Listar @SoloActivos, @TextoBusqueda", parametros)
                             .AsNoTracking() // Agrega esto para consultas de solo lectura
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Empresa_Listar> Dal_Empresa_ObtenerPorId(int iIdEmpresa)
        {
            List<Empresa_Listar> listaDatos = new List<Empresa_Listar>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdEmpresa };

                listaDatos = _context.Set<Empresa_Listar>()
                             .FromSqlRaw("EXEC sp_Empresa_ObtenerPorId @IdEmpresa", parametros)
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
