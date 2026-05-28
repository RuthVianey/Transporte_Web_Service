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
    public class AuthDAL
    {
        private readonly MiDbContext _context;

        public AuthDAL(MiDbContext context)
        {
            _context = context;
        }

        public int? Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            int? dato = 0;
            try
            {
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)iIdEmpresa);
                var _Email = new SqlParameter("@Email", (object)sEmail);
                var _PasswordIngresado = new SqlParameter("@PasswordIngresado", (object)sPasswordIngresado);

                object[] parametros = new object[] { _IdEmpresa, _Email, _PasswordIngresado };

                var resultado = _context.Set<Respuesta.ResultadoSP>().FromSqlRaw("EXEC sp_Usuario_Valida @IdEmpresa, @Email, @PasswordIngresado ", parametros).AsEnumerable().FirstOrDefault();
                dato = resultado?.Resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dato;

        }
        public List<RespuestaGeneral> Usuarios_Empresa(int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                var _IdEmpresa = new SqlParameter("@Email", (object)iIdEmpresa);

                object[] parametros = new object[] { _IdEmpresa };

                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_Usuarios_Empresa @Email ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}
