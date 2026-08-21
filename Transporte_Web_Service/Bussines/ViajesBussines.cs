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
        public async Task<ApiResponse<IEnumerable<Entity_Viaje_Listar?>>> Bs_Viaje_Listar(int IdEmpresa, int? IdSucursal, int? IdCliente, int? IdOperador, int? IdEstadoViaje, DateTime? FechaInicio, DateTime? FechaFin, string? TextoBusqueda)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Fail("La empresa es obligatoria.");

            var resumen = await _dal.Dal_Viaje_Listar(IdEmpresa, IdSucursal, IdCliente, IdOperador, IdEstadoViaje, FechaInicio, FechaFin, TextoBusqueda);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Viaje_Listar?>>> Bs_Viaje_ObtenerPorId(int IdViaje, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Fail("La empresa es obligatoria.");
            if (IdViaje <= 0) return ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Fail("El viaje es obligatorio.");

            var resumen = await _dal.Dal_Viaje_ObtenerPorId(IdViaje, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Viaje_Listar?>>.Success(resumen);
        }
        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Viaje_Guardar(int? IdViaje, int IdEmpresa, int? IdSucursal, int? IdOperador, int IdCliente, int? IdRuta, int IdEstadoViaje, DateTime? FechaSalida, DateTime? FechaLlegadaEstimada, DateTime? FechaLlegadaReal, string? Origen, string? Destino, decimal? KmInicial, decimal? KmFinal, decimal Ingreso, decimal? PrecioPactado, string? Observaciones)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdCliente <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El cliente es obligatorio.");
            if (IdEstadoViaje <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El estado del viaje es obligatorio.");

            var resumen = await _dal.Dal_Viaje_Guardar(IdViaje, IdEmpresa, IdSucursal, IdOperador, IdCliente, IdRuta, IdEstadoViaje, FechaSalida, FechaLlegadaEstimada, FechaLlegadaReal, Origen, Destino, KmInicial, KmFinal, Ingreso, PrecioPactado, Observaciones);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }
    }
}
