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
        private readonly IDbConnectionFactory _connectionFactory;

        public RentabilidadDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Entity_Rentabilidad_ListarViajes?> Dal_Rentabilidad_ListarViajes(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin, int? IdCliente,
                                                                                int? IdUnidad, int? IdRuta )  
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Rentabilidad_ListarViajes>("dbo.sp_Rentabilidad_ListarViajes",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    FechaInicio = FechaInicio,
                    FechaFin = FechaFin,
                    IdCliente = IdCliente,
                    IdUnidad = IdUnidad,
                    IdRuta = IdRuta
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_Rentabilidad_PorCliente?> Dal_Rentabilidad_PorCliente(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, DateTime? FechaFin )
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Rentabilidad_PorCliente>("dbo.sp_Rentabilidad_PorCliente",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdSucursal = IdSucursal,
                    FechaInicio = FechaInicio,
                    FechaFin = FechaFin
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
