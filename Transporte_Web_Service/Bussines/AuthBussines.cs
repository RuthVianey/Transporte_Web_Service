using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class AuthBussines
    {
        private readonly AuthDAL _dal;

        public AuthBussines(AuthDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<int?>> Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<int?>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);

            if (resumen == null)
            {
                return ApiResponse<int?>.Fail("No se encontro informacion del usuario.");
            }

            return ApiResponse<int?>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_UsuarioEmpresa?>>> Usuarios_Empresa(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return ApiResponse<IEnumerable<Entity_UsuarioEmpresa?>>.Fail("El email es obligatorio para consultar empresas.");
            }

            var empresas = (await _dal.Usuarios_Empresa(email)).ToList();
            return ApiResponse<IEnumerable<Entity_UsuarioEmpresa?>>.Success(empresas);
        }
    }
}
