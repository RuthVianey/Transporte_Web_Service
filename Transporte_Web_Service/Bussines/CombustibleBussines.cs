using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class CombustibleBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly CombustibleDAL _dal;

        public CombustibleBussines(CombustibleDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_CargaCombustible_Eliminar(int IdCarga, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_CargaCombustible_Eliminar(IdCarga, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_CargaCombustible_Guardar(int IdCarga, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, string Fecha, decimal Litros, decimal PrecioLitro, decimal Km, decimal Odometro, decimal RendimientoKmPorLitro, string Referencia)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_CargaCombustible_Guardar(IdCarga, IdEmpresa, IdSucursal, IdUnidad, IdViaje, Fecha, Litros, PrecioLitro, Km, Odometro, RendimientoKmPorLitro, Referencia);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardo la información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_CargaCombustible_ListarPorViaje?>>> Bs_CargaCombustible_ListarPorViaje(int IdEmpresa, int IdViaje)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_CargaCombustible_ListarPorViaje?>>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_CargaCombustible_ListarPorViaje(IdEmpresa, IdViaje);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_CargaCombustible_ListarPorViaje?>>.Fail("No se guardo la información.");
            }
            return ApiResponse<IEnumerable<Entity_CargaCombustible_ListarPorViaje?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_CargaCombustible_ObtenerPorId?>>> Bs_CargaCombustible_ObtenerPorId(int IdEmpresa, int IdCarga)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_CargaCombustible_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }


            var resumen = await _dal.Dal_CargaCombustible_ObtenerPorId(IdEmpresa, IdCarga);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_CargaCombustible_ObtenerPorId?>>.Fail("No se guardo la información.");
            }
            return ApiResponse<IEnumerable<Entity_CargaCombustible_ObtenerPorId?>>.Success(resumen);
        }
    }
}
