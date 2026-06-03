using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ClientesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly ClientesDAL _dal;

        public ClientesBussines(ClientesDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_Cliente_Desactivar(iIdCliente, iIdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Obtener_Cliente_PorId>> Bs_Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<Entity_Obtener_Cliente_PorId>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<Entity_Obtener_Cliente_PorId>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Obtener_Cliente_PorId>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Obtener_Cliente_PorId>> Bs_Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<Entity_Obtener_Cliente_PorId>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<Entity_Obtener_Cliente_PorId>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Obtener_Cliente_PorId>.Success(resumen);
        }
        
    }
}
