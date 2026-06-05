using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class OperadoresBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly OperadoresDAL _dal;

        public OperadoresBussines(OperadoresDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Operador_Desactivar(iIdOperador, iIdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>> Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>> Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            if (iIdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Operador_ObtenerPorId?>>.Success(resumen);
        }

    }
}
