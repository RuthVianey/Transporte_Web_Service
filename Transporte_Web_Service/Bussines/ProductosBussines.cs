using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ProductosBussines
    {
        private readonly ProductosDAL _dal;

        public ProductosBussines(ProductosDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_Producto_Listar?>>> Bs_Producto_Listar(int IdEmpresa, int? IdSucursal, bool SoloActivos, string? TextoBusqueda)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Fail("La empresa es obligatoria.");

            var resumen = await _dal.Dal_Producto_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Producto_Listar?>>> Bs_Producto_ObtenerPorId(int IdProducto, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Fail("La empresa es obligatoria.");
            if (IdProducto <= 0) return ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Fail("El producto es obligatorio.");

            var resumen = await _dal.Dal_Producto_ObtenerPorId(IdProducto, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Producto_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Producto_Guardar(int? IdProducto, int IdEmpresa, int? IdSucursal, string? Clave, string Descripcion, string? UnidadMedida, string? ClaveSAT, bool MaterialPeligroso, bool Activo)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (string.IsNullOrWhiteSpace(Descripcion)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La descripción del producto es obligatoria.");

            var resumen = await _dal.Dal_Producto_Guardar(IdProducto, IdEmpresa, IdSucursal, Clave, Descripcion, UnidadMedida, ClaveSAT, MaterialPeligroso, Activo);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardó la información.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Producto_Desactivar(int IdProducto, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdProducto <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El producto es obligatorio.");

            var resumen = await _dal.Dal_Producto_Desactivar(IdProducto, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se desactivó la información.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }
    }
}
