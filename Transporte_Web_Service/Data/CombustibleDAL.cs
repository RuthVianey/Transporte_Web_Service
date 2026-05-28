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
    public class CombustibleDAL
    {
        private readonly MiDbContext _context;

        public CombustibleDAL(MiDbContext context)
        {
            _context = context;
        }

        public List<RespuestaGeneral> Dal_CargaCombustible(int IdCarga, int IdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();

            try
            {
                var _IdCarga = new SqlParameter("@IdCarga", (object)IdCarga);
                var _IdEmpresa = new SqlParameter("@IdEmpresa", (object)IdEmpresa);
                
                object[] parametros = new object[] { _IdCarga, _IdEmpresa };
                listaDatos = _context.Set<RespuestaGeneral>().FromSqlRaw("EXEC sp_CargaCombustible_Eliminar @IdCarga, @IdEmpresa ", parametros).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listaDatos;
        }
    }
}


