using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class SatCatalogosBussines
    {
        private readonly SatCatalogosDAL _dal;

        public SatCatalogosBussines(SatCatalogosDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_SatCatalogoProdServ>>> Bs_SatCatalogoProdServ_Listar(string? textoBusqueda, bool soloVigentes, int top)
        {
            var datos = await _dal.Dal_SatCatalogoProdServ_Listar(Limpiar(textoBusqueda), soloVigentes, NormalizarTop(top));
            return ApiResponse<IEnumerable<Entity_SatCatalogoProdServ>>.Success(datos);
        }

        public async Task<ApiResponse<IEnumerable<Entity_SatCatalogoRegimenFiscal>>> Bs_SatCatalogoRegimenFiscal_Listar(string? textoBusqueda, byte? tipoPersona, int top)
        {
            var datos = await _dal.Dal_SatCatalogoRegimenFiscal_Listar(Limpiar(textoBusqueda), tipoPersona, NormalizarTop(top));
            return ApiResponse<IEnumerable<Entity_SatCatalogoRegimenFiscal>>.Success(datos);
        }

        public async Task<ApiResponse<IEnumerable<Entity_SatCatalogoUM>>> Bs_SatCatalogoUM_Listar(string? textoBusqueda, int top)
        {
            var datos = await _dal.Dal_SatCatalogoUM_Listar(Limpiar(textoBusqueda), NormalizarTop(top));
            return ApiResponse<IEnumerable<Entity_SatCatalogoUM>>.Success(datos);
        }

        private static string? Limpiar(string? valor) => string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();

        private static int NormalizarTop(int top) => top <= 0 ? 100 : Math.Min(top, 500);
    }
}
