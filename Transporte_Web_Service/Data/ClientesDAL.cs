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
    public class ClientesDAL
    {
        private readonly MiDbContext _context;

        public ClientesDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdCliente = new SqlParameter("@IdCliente", (object)iIdCliente);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdCliente, _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Cliente_Desactivar @IdCliente, @IdEmpresa ", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<RespuestaGeneral> Dal_Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdCliente = new SqlParameter("@IdCliente", (object)iIdCliente);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)iIdSucursal);
                var _Nombre = new SqlParameter("@Nombre", (object)sNombre);
                var _RFC = new SqlParameter("@RFC", (object)sRFC);
                var _Telefono = new SqlParameter("@Telefono", (object)sTelefono);
                var _Email = new SqlParameter("@Email", (object)sEmail);
                var _RegimenFiscal = new SqlParameter("@RegimenFiscal", (object)iRegimenFiscal);
                var _Activo = new SqlParameter("@Activo", (object)bActivo);


                object[] parametros = new object[] { _IdCliente, _IdEmpresa, _IdSucursal, _Nombre, _RFC, _Telefono, _Email, _RegimenFiscal, _Activo };

                listaDatos = _context.Set<RespuestaGeneral>()
                             .FromSqlRaw("EXEC sp_Cliente_Guardar @IdCliente, @IdEmpresa, @IdSucursal, @Nombre, @RFC, @Telefono, @Email, @RegimenFiscal, @Activo ", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        public List<Ent_Obtener_Cliente_PorId> Dal_Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            List<Ent_Obtener_Cliente_PorId> listaDatos = new List<Ent_Obtener_Cliente_PorId>();
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _IdSucursal = new SqlParameter("@IdSucursal", (object)iIdSucursal);
                var _SoloActivos = new SqlParameter("@SoloActivos", (object)sSoloActivos);
                var _TextoBusqueda = new SqlParameter("@TextoBusqueda", (object)sTextoBusqueda);


                object[] parametros = new object[] { _IdEmpresa, _IdSucursal, _SoloActivos, _TextoBusqueda };

                listaDatos = _context.Set<Ent_Obtener_Cliente_PorId>().
                             FromSqlRaw("EXEC sp_Cliente_Listar @IdEmpresa, @IdSucursal, @SoloActivos, @TextoBusqueda ", parametros)
                            .AsNoTracking() // Agrega esto para consultas de solo lectura
                            .ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }

        public List<Ent_Obtener_Cliente_PorId> Dal_Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            List<Ent_Obtener_Cliente_PorId> listaDatos = new List<Ent_Obtener_Cliente_PorId>();
            try
            {
                var _IdCliente = new SqlParameter("@IdCliente", (object)iIdCliente);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdCliente, _IdEmpresa };

                listaDatos = _context.Set<Ent_Obtener_Cliente_PorId>()
                             .FromSqlRaw("EXEC sp_Cliente_ObtenerPorId @IdCliente, @IdEmpresa ", parametros)
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
