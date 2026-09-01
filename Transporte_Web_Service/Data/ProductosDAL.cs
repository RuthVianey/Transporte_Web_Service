using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class ProductosDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductosDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Entity_Producto_Listar?>> Dal_Producto_Listar(int IdEmpresa, int? IdSucursal, bool SoloActivos, string? TextoBusqueda)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Producto_Listar?>("dbo.sp_Producto_Listar",
                new { IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_Producto_Listar?>> Dal_Producto_ObtenerPorId(int IdProducto, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Producto_Listar?>("dbo.sp_Producto_ObtenerPorId",
                new { IdProducto, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Producto_Guardar(int? IdProducto, int IdEmpresa, int? IdSucursal, string? Clave, string Descripcion, string? UnidadMedida, string? ClaveSAT, bool MaterialPeligroso, bool Activo)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Producto_Guardar",
                new { IdProducto, IdEmpresa, IdSucursal, Clave, Descripcion, UnidadMedida, ClaveSAT, MaterialPeligroso, Activo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_Producto_Desactivar(int IdProducto, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_Producto_Desactivar",
                new { IdProducto, IdEmpresa },
                commandType: CommandType.StoredProcedure);
        }
    }
}
