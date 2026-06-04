using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ViajesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly ViajesDAL _dal;

        public ViajesBussines(ViajesDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {
            var resumen = await _dal.Dal_EstadoViaje_Guardar(IdEstadoViaje, Descripcion);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>> Bs_EstadoViaje_Listar()
        {
            var resumen = await _dal.Dal_EstadoViaje_Listar();

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>.Success(resumen);
        }
        

        public async Task<ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>> Bs_EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {
            var resumen = await _dal.Dal_EstadoViaje_ObtenerPorId(IdEstadoViaje);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_EstadoViaje_Listar?>>.Success(resumen);
        }

    }
}
