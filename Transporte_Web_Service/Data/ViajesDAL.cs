using Dapper;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transporte_Web_Service.Data
{
    public class ViajesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        //public ViajesDAL(DbConnectionFactory connectionFactory)
        public ViajesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_EstadoViaje_Guardar",
                new
                {
                    IdEstadoViaje = IdEstadoViaje,
                    Descripcion = Descripcion
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_EstadoViaje_Listar?>> Dal_EstadoViaje_Listar()
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_EstadoViaje_Listar?>("dbo.sp_EstadoViaje_Listar",
                new
                {
                     
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_EstadoViaje_Listar?>> Dal_EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_EstadoViaje_Listar?>("dbo.sp_EstadoViaje_ObtenerPorId",
                new
                {
                    IdEstadoViaje = IdEstadoViaje
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
