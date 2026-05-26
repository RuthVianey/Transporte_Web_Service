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
    public class OperadoresDAL
    {
        private readonly MiDbContext _context;

        public OperadoresDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<Operador_ObtenerPorId> Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            List<Operador_ObtenerPorId> listaDatos = new List<Operador_ObtenerPorId>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _IdOperador = new SqlParameter("@IdOperador", (object)iIdOperador);

                object[] parametros = new object[] { _IdEmpresa, _IdOperador };

                listaDatos = _context.Set<Operador_ObtenerPorId>().FromSqlRaw("EXEC sp_Operador_ObtenerPorId @IdOperador, @IdEmpresa ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Operador_ObtenerPorId> Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            List<Operador_ObtenerPorId> listaDatos = new List<Operador_ObtenerPorId>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)iIdSucursal);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)bSoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)sTextoBusqueda);

                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Operador_ObtenerPorId>().FromSqlRaw("EXEC sp_Operador_Listar @IdEmpresa, @IdSucursal, @SoloActivos, @TextoBusqueda ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdOperador = new SqlParameter("@IdOperador", (object)iIdOperador);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)iIdSucursal);
                var _Nombre = new SqlParameter("@Nombre", (object)sNombre);
                var _Licencia = new SqlParameter("@Licencia", (object)sLicencia);
                var _TipoLicencia = new SqlParameter("@TipoLicencia", (object)sTipoLicencia);
                var _FechaVencimientoLicencia = new SqlParameter("@FechaVencimientoLicencia", (object)sFechaVencimientoLicencia);
                var _CURP = new SqlParameter("@CURP", (object)sCURP);
                var _Telefono = new SqlParameter("@Telefono", (object)sTelefono);
                var _Activo = new SqlParameter("@Activo", (object)bActivo);

                object[] parametros = new object[] { _IdOperador, _IdEmpresa, _IdSucursal, _Nombre, _Licencia, _TipoLicencia, _FechaVencimientoLicencia, _CURP, _Telefono, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Operador_Guardar @IdOperador, @IdEmpresa, @IdSucursal, @Nombre, @Licencia, @TipoLicencia, @FechaVencimientoLicencia, @CURP, @Telefono, @Activo ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<RespuestaGeneral> Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdOperador = new SqlParameter("@IdOperador", (object)iIdOperador);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdOperador, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Operador_Desactivar @IdOperador, @IdEmpresa ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}
