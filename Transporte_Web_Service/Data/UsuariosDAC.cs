using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Transporte_Web_Service.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Transporte_Web_Service.Controllers;
using System.Net.NetworkInformation;

namespace Transporte_Web_Service.Data
{
    public class UsuariosDAC
    {
        private readonly MiDbContext _context;

        public UsuariosDAC(MiDbContext context)
        {
            _context = context;
        }
        
        /*COMIENZA USUARIO*/
        public List<RespuestaGeneral> Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdUsuario = new SqlParameter("@IdUsuario", (object)iIdUsuario);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _Nombre = new SqlParameter("@Nombre", (object)sNombre);
                var _Email = new SqlParameter("@Email", (object)sEmail);
                var _Contrasenia = new SqlParameter("@Contrasenia", (object)sContrasenia);
                var _Sucursal = new SqlParameter("@IdSucursal", (object)iIdSucursal);

                object[] parametros = new object[] { _IdUsuario, _IdEmpresa, _Nombre, _Email, _Contrasenia, _Sucursal };

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Usuario_Guardar @IdUsuario, @IdEmpresa, @Nombre, @Email, @Contrasenia, @IdSucursal ", parametros).ToList();
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
        
    }

}
