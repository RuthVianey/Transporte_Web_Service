using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class GastosBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly GastosDAL _dal;

        public GastosBussines(GastosDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Gasto_Eliminar(int IdGasto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Gasto_Eliminar(IdGasto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Gasto_Guardar(int IdGasto, int IdEmpresa, int IdSucursal, int IdTipoGasto, int IdViaje, int IdUnidad, string Fecha, decimal Monto, string Referencia, string Descripcion, byte EsFacturable)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Gasto_Guardar(IdGasto, IdEmpresa, IdSucursal, IdTipoGasto, IdViaje, IdUnidad, Fecha, Monto, Referencia, Descripcion, EsFacturable);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Gasto_ListarPorViaje?>>> Bs_Gasto_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Gasto_ListarPorViaje?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Gasto_ListarPorViaje(IdViaje, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Gasto_ListarPorViaje?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Gasto_ListarPorViaje?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Gasto_ObtenerPorId?>>> Bs_Gasto_ObtenerPorId(int IdGasto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Gasto_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Gasto_ObtenerPorId(IdGasto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Gasto_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Gasto_ObtenerPorId?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoGasto_Desactivar(int IdTipoGasto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoGasto_Desactivar(IdTipoGasto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoGasto_Guardar(int IdTipoGasto, int IdEmpresa, string Descripcion, byte EsCostoDirecto, byte EsMantenimiento, byte EsCombustible, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoGasto_Guardar(IdTipoGasto, IdEmpresa, Descripcion, EsCostoDirecto, EsMantenimiento, EsCombustible, Activo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>> Bs_TipoGasto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoGasto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>> Bs_TipoGasto_ObtenerPorId(int IdTipoGasto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoGasto_ObtenerPorId(IdTipoGasto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_TipoGasto_Listar?>>.Success(resumen);
        }
    }
}
