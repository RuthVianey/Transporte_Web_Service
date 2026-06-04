using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class UsuariosBS
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";

        private readonly UsuariosDAC _dac;

        public UsuariosBS(UsuariosDAC dac)
        {
            _dac = dac;
        }

        /*COMIENZA USUARIO*/

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dac.Usuario_Guardar(iIdUsuario, iIdEmpresa, sNombre, sEmail, sContrasenia, iIdSucursal);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }
    }
}
