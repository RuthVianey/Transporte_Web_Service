using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ImpuestosBussines
    {
        private readonly ImpuestosDAL _dal;
        public ImpuestosBussines(ImpuestosDAL dal) => _dal = dal;

        public async Task<ApiResponse<IEnumerable<Entity_Impuesto?>>> Bs_Impuesto_Listar(int idEmpresa, bool soloActivos)
        {
            if (idEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Impuesto?>>.Fail("La empresa es obligatoria.");
            return ApiResponse<IEnumerable<Entity_Impuesto?>>.Success(await _dal.Dal_Impuesto_Listar(idEmpresa, soloActivos));
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Impuesto_Guardar(int? idImpuesto, int idEmpresa, string descripcion, decimal? porcentaje, string operacion, string? claveSatImpuesto, string ambito, bool afectaCosto, bool activo)
        {
            if (idEmpresa <= 0 || string.IsNullOrWhiteSpace(descripcion) || porcentaje is < 0 || (operacion != "+" && operacion != "-") || (ambito != "F" && ambito != "L"))
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Verifica los datos del impuesto.");
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(await _dal.Dal_Impuesto_Guardar(idImpuesto, idEmpresa, descripcion, porcentaje, operacion, claveSatImpuesto, ambito, afectaCosto, activo));
        }

        public async Task<ApiResponse<IEnumerable<Entity_ProductoImpuesto?>>> Bs_ProductoImpuesto_Listar(int idEmpresa, int idProducto, bool soloActivos)
        {
            if (idEmpresa <= 0 || idProducto <= 0) return ApiResponse<IEnumerable<Entity_ProductoImpuesto?>>.Fail("El producto y la empresa son obligatorios.");
            return ApiResponse<IEnumerable<Entity_ProductoImpuesto?>>.Success(await _dal.Dal_ProductoImpuesto_Listar(idEmpresa, idProducto, soloActivos));
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_ProductoImpuesto_Guardar(int idEmpresa, int idProducto, int idImpuesto, bool activo)
        {
            if (idEmpresa <= 0 || idProducto <= 0 || idImpuesto <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El producto, impuesto y empresa son obligatorios.");
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(await _dal.Dal_ProductoImpuesto_Guardar(idEmpresa, idProducto, idImpuesto, activo));
        }
    }
}
