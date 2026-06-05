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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Data
{
    public class SeguridadDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public SeguridadDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Sucursal_Desactivar(int IdSucursal, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Sucursal_Desactivar",
                new
                {
                    IdSucursal = IdSucursal,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Sucursal_Guardar(int IdSucursal, int IdEmpresa, string Nombre, string NombreCorto, string Codigo, string Calle, string Colonia, string Municipio, string Estado, string CodigoPostal, string Telefono, byte Activo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Sucursal_Guardar",
                new
                {
                    IdSucursal = IdSucursal,
                    IdEmpresa = IdEmpresa,
                    Nombre = Nombre,
                    NombreCorto = NombreCorto,
                    Codigo = Codigo,
                    Calle = Calle,
                    Colonia = Colonia,
                    Municipio = Municipio,
                    Estado = Estado,
                    CodigoPostal = CodigoPostal,
                    Telefono = Telefono,
                    Activo = Activo
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Sucursal_Listar?>> Dal_Sucursal_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Sucursal_Listar?>("dbo.sp_Sucursal_Listar",
                new
                {
                    IdEmpresa = IdEmpresa,
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Entity_Sucursal_Listar?>> Dal_Sucursal_ObtenerPorId(int IdSucursal, int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Sucursal_Listar?>("dbo.sp_Sucursal_ObtenerPorId",
                new
                {
                    IdSucursal = IdSucursal,
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}


