
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
    public class GeneralesDAC //: ConexionBD
    {
        //public GeneralesDAC(string BD) : base(BD) { }

        private readonly MiDbContext _context;

        public GeneralesDAC(MiDbContext context)
        {
            _context = context;
        }

        /*COMIENZA EMPRESA*/
        public List<RespuestaGeneral> Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
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

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Empresa_Guardar @IdEmpresa, @Nombre, @NombreCorto, @RFC, @Calle, @Colonia, @Municipio, @Estado, @CodigoPostal, @Telefono, @RutaLogo, @Activo", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Empresa_Desactivar(int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Empresa_Desactivar @IdEmpresa", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Empresa_Listar> Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            List<Empresa_Listar> listaDatos = new List<Empresa_Listar>();
            try
            {
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)bSoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)sTextoBusqueda);

                object[] parametros = new object[] { _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Empresa_Listar>().FromSqlRaw("EXEC sp_Empresa_Listar @SoloActivos, @TextoBusqueda", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Empresa_Listar> Empresa_ObtenerPorId(int iIdEmpresa)
        {
            List<Empresa_Listar> listaDatos = new List<Empresa_Listar>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdEmpresa };

                listaDatos = _context.Set<Empresa_Listar>().FromSqlRaw("EXEC sp_Empresa_ObtenerPorId @IdEmpresa", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Programa_Listar> Dal_Programa_Listar()
        {
            List<Ent_Programa_Listar> listaDatos = new List<Ent_Programa_Listar>();
            try
            {
                object[] parametros = new object[] {  };

                listaDatos = _context.Set<Ent_Programa_Listar>()
                             .FromSqlRaw("EXEC Programa_Listar ", parametros)
                             .AsNoTracking()
                             .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }








        //public int? Actualizar_Empresa(int iTipo, int iIdEmpresa, string sNombre_Completo, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo)
        //{
        //    int? dato = null;
        //    try
        //    {
        //        var _Tipo = new SqlParameter("@Tipo", iTipo == null ? DBNull.Value : (object)iTipo);
        //        var _IdEmpresa = new SqlParameter("@IdEmpresa", iIdEmpresa == null ? DBNull.Value : (object)iIdEmpresa);
        //        var _Nombre_Completo = new SqlParameter("@Nombre_Completo", sNombre_Completo == null ? DBNull.Value : (object)sNombre_Completo);
        //        var _Nombre_Corto = new SqlParameter("@Nombre_Corto", sNombre_Corto == null ? DBNull.Value : (object)sNombre_Corto);
        //        var _RFC = new SqlParameter("@RFC", sRFC == null ? DBNull.Value : (object)sRFC);
        //        var _Calle = new SqlParameter("@Calle", sCalle == null ? DBNull.Value : (object)sCalle);
        //        var _Colonia = new SqlParameter("@Colonia", sColonia == null ? DBNull.Value : (object)sColonia);
        //        var _Municipio = new SqlParameter("@Municipio", sMunicipio == null ? DBNull.Value : (object)sMunicipio);
        //        var _Estado = new SqlParameter("@Estado", sEstado == null ? DBNull.Value : (object)sEstado);
        //        var _Codigo_Postal = new SqlParameter("@Codigo_Postal", sCodigo_Postal == null ? DBNull.Value : (object)sCodigo_Postal);
        //        var _Telefono = new SqlParameter("@Telefono", sTelefono == null ? DBNull.Value : (object)sTelefono);
        //        var _RutaLogo = new SqlParameter("@RutaLogo", sRutaLogo == null ? DBNull.Value : (object)sRutaLogo);

        //        var resultado = _context.Set<Respuesta.ResultadoSP>().FromSqlRaw("EXEC sp_Empresa @Tipo, @IdEmpresa, @Nombre_Completo, @Nombre_Corto, @RFC, @Calle, @Colonia, @Municipio, @Estado, @Codigo_Postal, @Telefono, @RutaLogo",_Tipo, _IdEmpresa, _Nombre_Completo, _Nombre_Corto, _RFC, _Calle, _Colonia, _Municipio, _Estado, _Codigo_Postal, _Telefono, _RutaLogo).AsEnumerable().FirstOrDefault();
        //        dato = resultado?.Resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return dato;
        //}

        //public List<Obtienen_Datos_Empresa> Obtienen_Datos_Empresa(int iIdEmpresa)
        //{
        //    List<Obtienen_Datos_Empresa> listaDatos = new List<Obtienen_Datos_Empresa>();
        //    try
        //    {   
        //        var _IdEmpresa = new SqlParameter("@Idempresa", iIdEmpresa == null ? DBNull.Value : (object)iIdEmpresa);

        //        listaDatos = _context.Obtienen_Datos_Empresa.FromSqlRaw("sp_Empresa_Datos @Idempresa ", _IdEmpresa).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return listaDatos;
        //}

        //public List<Usuarios_Empresa> Obtiene_Empresa_Por_Correo(string sEmail)
        //{
        //    List<Usuarios_Empresa> listaDatos = new List<Usuarios_Empresa>();
        //    try
        //    {
        //        var _Email = new SqlParameter("@Email", sEmail == null ? DBNull.Value : (object)sEmail);

        //        listaDatos = _context.Usuarios_Empresa.FromSqlRaw("sp_Usuarios_Empresa @Idempresa ", _Email).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return listaDatos;
        //}

        ////Nuevo

        //public List<Obtienen_Datos_Empresa> Empresa_Get(int iIdEmpresa)
        //{
        //    List<Obtienen_Datos_Empresa> listaDatos = new List<Obtienen_Datos_Empresa>();
        //    try
        //    {
        //        var _IdEmpresa = new SqlParameter("@Idempresa", iIdEmpresa == null ? DBNull.Value : (object)iIdEmpresa);

        //        listaDatos = _context.Obtienen_Datos_Empresa.FromSqlRaw("sp_Empresa_Get @Idempresa ", _IdEmpresa).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return listaDatos;
        //}

        //public int? Usuario_Delete(int iIdEmpresa, string sNombre, string sNombreCorto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo)
        //{
        //    int? dato = 0;
        //    try
        //    {
        //        var _iIdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
        //            var _sNombre = new SqlParameter("@Nombre", (object)sNombre);
        //            var _sNombreCorto = new SqlParameter("@NombreCorto", (object)sNombreCorto);
        //            var _sRFC = new SqlParameter("@RFC", (object)sRFC);
        //            var _sCalle = new SqlParameter("@Calle", (object)sCalle);
        //            var _sColonia = new SqlParameter("@Colonia", (object)sColonia);
        //            var _sMunicipio = new SqlParameter("@Municipio", (object)sMunicipio);
        //            var _sEstado = new SqlParameter("@Estado", (object)sEstado);
        //            var _sCodigo_Postal = new SqlParameter("@Codigo_Postal", (object)sCodigo_Postal);
        //            var _sTelefono = new SqlParameter("@Telefono", (object)sTelefono);
        //            var _sRutaLogo = new SqlParameter("@RutaLogo", (object)sRutaLogo);

        //        object[] parametros = new object[] { _iIdEmpresa, _sNombre, _sNombreCorto, _sRFC, _sCalle, _sColonia, _sMunicipio, _sEstado, _sCodigo_Postal, _sTelefono, _sRutaLogo };

        //        var resultado = _context.Set<Respuesta.ResultadoSP>().FromSqlRaw("EXEC sp_Empresa_Save @IdEmpresa, @Nombre, @NombreCorto, @RFC, @Calle, @Colonia, @Municipio, @Estado, @Codigo_Postal, @Telefono, @RutaLogo ", parametros).AsEnumerable().FirstOrDefault();
        //        dato = resultado?.Resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return dato;

        //}

    }
}
