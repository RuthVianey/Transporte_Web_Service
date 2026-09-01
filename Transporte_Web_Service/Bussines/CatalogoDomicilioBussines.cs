using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class CatalogoDomicilioBussines
    {
        private readonly CatalogoDomicilioDAL _dal;

        public CatalogoDomicilioBussines(CatalogoDomicilioDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_Catalogo_Domicilio?>>> Bs_Catalogo_Domicilio_Listar(string? codigoPostal, string? asentamiento, string? estado, string? municipio)
        {
            codigoPostal = codigoPostal?.Trim() ?? string.Empty;
            asentamiento = asentamiento?.Trim() ?? string.Empty;
            estado = estado?.Trim() ?? string.Empty;
            municipio = municipio?.Trim() ?? string.Empty;

            var datos = await _dal.Dal_Catalogo_Domicilio_Listar(codigoPostal, asentamiento, estado, municipio);

            if (datos == null)
            {
                return ApiResponse<IEnumerable<Entity_Catalogo_Domicilio?>>.Fail("No se encontró información.");
            }

            return ApiResponse<IEnumerable<Entity_Catalogo_Domicilio?>>.Success(datos);
        }
    }
}
