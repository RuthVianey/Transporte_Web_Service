using Dapper;
using Humanizer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using Transporte_Web_Service.Controllers;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transporte_Web_Service.Data
{
    public class EmpresaDAL
    {
        //private readonly MiDbContext _context;
        private readonly IDbConnectionFactory _connectionFactory;

        public EmpresaDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Empresa_Desactivar(int IdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Empresa_Desactivar",
                new
                {
                    IdEmpresa = IdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Empresa_Guardar",
                new
                {
                    IdEmpresa = iIdEmpresa,
                    Nombre = sNombre,
                    NombreCorto = sNombre_Corto,
                    RFC = sRFC,
                    Calle = sCalle,
                    Colonia = sColonia,
                    Municipio = sMunicipio,
                    Estado = sEstado,
                    CodigoPostal = sCodigo_Postal,
                    Telefono = sTelefono,
                    RutaLogo = sRutaLogo,
                    Activo = bActivo
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_Empresa_Listar?>> Dal_Empresa_Listar(byte SoloActivos, string? TextoBusqueda)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Empresa_Listar?>("dbo.sp_Empresa_Listar",
                new
                {
                    SoloActivos = SoloActivos,
                    TextoBusqueda = TextoBusqueda
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Entity_Empresa_Listar?>> Dal_Empresa_ObtenerPorId(int iIdEmpresa)
        {

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Empresa_Listar?>("dbo.sp_Empresa_ObtenerPorId",
                new
                {
                    IdEmpresa = iIdEmpresa
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

