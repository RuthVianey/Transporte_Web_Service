using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class RutasBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly RutasDAL _dal;

        public RutasBussines(RutasDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Ruta_Desactivar(int IdRuta, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Ruta_Desactivar(IdRuta, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Ruta_Guardar(int IdRuta, int IdEmpresa, int IdSucursal, string Nombre, string Origen, string Destino, decimal DistanciaKm, int TiempoEstimadoMin, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Ruta_Guardar(IdRuta, IdEmpresa, IdSucursal, Nombre, Origen, Destino, DistanciaKm, TiempoEstimadoMin, Activo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Ruta_Listar?>>> Bs_Ruta_Listar(int IdEmpresa, int IdSucursal, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Ruta_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Ruta_Listar?>>> Bs_Ruta_ObtenerPorId(int IdRuta, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Ruta_ObtenerPorId(IdRuta, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Ruta_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_RutaDetalle_Eliminar(int IdRutaDetalle, int IdRuta)
        {
            var resumen = await _dal.Dal_RutaDetalle_Eliminar(IdRutaDetalle, IdRuta);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_RutaDetalle_Guardar(int IdRutaDetalle, int IdRuta, int Orden, string Punto, decimal Latitud, decimal Longitud, string Tipo)
        {
            var resumen = await _dal.Dal_RutaDetalle_Guardar(IdRutaDetalle, IdRuta, Orden, Punto, Latitud, Longitud, Tipo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>> Bs_RutaDetalle_Listar(int IdRuta)
        {
            var resumen = await _dal.Dal_RutaDetalle_Listar(IdRuta);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>> Bs_RutaDetalle_ObtenerPorId(int IdRutaDetalle, int IdRuta)
        {
            var resumen = await _dal.Dal_RutaDetalle_ObtenerPorId(IdRutaDetalle, IdRuta);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RutaDetalle_Listar?>>.Success(resumen);
        }
    }
}
