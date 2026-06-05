using System.Runtime.InteropServices.ObjectiveC;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class EmpresaBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";

        private readonly EmpresaDAL _dal;

        public EmpresaBussines(EmpresaDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Empresa_Desactivar(int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Empresa_Desactivar(IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Empresa_Listar?>>> Bs_Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {

            var resumen = await _dal.Dal_Empresa_Listar(bSoloActivos, sTextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Empresa_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Empresa_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Empresa_Listar?>>> Bs_Empresa_ObtenerPorId(int iIdEmpresa)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Empresa_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Empresa_ObtenerPorId(iIdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Empresa_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Empresa_Listar?>>.Success(resumen);
        }
    }
}
