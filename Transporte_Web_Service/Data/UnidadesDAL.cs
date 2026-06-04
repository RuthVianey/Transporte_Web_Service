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
    public class UnidadesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public UnidadesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<Entity_RespuestaGeneral?> Dal_TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_TipoUnidad_Desactivar",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_TipoUnidad_Guardar",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa,
                    Descripcion = Descripcion,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_TipoUnidad_Listar?> Dal_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_TipoUnidad_Listar>("dbo.sp_TipoUnidad_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_TipoUnidad_ObtenerPorId",
                new
                {
                    IdTipoUnidad = IdTipoUnidad,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
