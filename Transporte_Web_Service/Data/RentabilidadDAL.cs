using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;


namespace Transporte_Web_Service.Data
{
    public class RentabilidadDAL
    {
        //private readonly MiDbContext _context;

        //public RentabilidadDAL(MiDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IDbConnectionFactory _connectionFactory;

        public RentabilidadDAL(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Entity_Rentabilidad_ListarViajes?> ObtenerResumenAsync(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Rentabilidad_ListarViajes>("dbo.Dashboard_ResumenOperativo",
                new
                {
                    IdEmpresa = idEmpresa,
                    IdSucursal = idSucursal,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
