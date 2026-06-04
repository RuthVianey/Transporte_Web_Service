using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Data
{
    public class RolesDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public RolesDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<Entity_RespuestaGeneral?> Dal_Rol_Desactivar(int IdRol, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Rol_Desactivar",
                new
                {
                    IdRol = IdRol,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RespuestaGeneral?> Dal_Rol_Guardar(int IdRol, int IdEmpresa, string Nombre, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_Rol_Guardar",
                new
                {
                    IdRol = IdRol,
                    IdEmpresa = IdEmpresa,
                    Nombre = Nombre,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Listar_Roles?> Dal_Rol_Listar(int IdEmpresa, byte SoloActivos)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Listar_Roles>("dbo.sp_Rol_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_Listar_Roles?> Dal_Rol_ObtenerPorId(int IdEmpresa, int IdRol)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_Listar_Roles>("dbo.sp_Rol_ObtenerPorId",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdRol = IdRol
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Entity_RespuestaGeneral?> Dal_RolPrograma_GuardarPermiso(int IdRol, int IdEmpresa, int IdPrograma, byte PuedeLeer, byte PuedeEscribir, byte PuedeEliminar)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RespuestaGeneral>("dbo.sp_RolPrograma_GuardarPermiso",
                new
                {
                    IdRol = IdRol,
                    IdEmpresa = IdEmpresa,
                    IdPrograma = IdPrograma,
                    PuedeLeer = PuedeLeer,
                    PuedeEscribir = PuedeEscribir,
                    PuedeEliminar = PuedeEliminar
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Entity_RolPrograma_ListarPorRol?> Dal_RolPrograma_ListarPorRol(int IdEmpresa, int IdRol)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Entity_RolPrograma_ListarPorRol>("dbo.sp_RolPrograma_ListarPorRol",
                new
                {
                    IdEmpresa = IdEmpresa,
                    IdRol = IdRol
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
