using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class UnidadesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly UnidadesDAL _dal;

        public UnidadesBussines(UnidadesDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoUnidad_Desactivar(IdTipoUnidad, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoUnidad_Guardar(IdTipoUnidad, IdEmpresa, Descripcion, Activo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>> Bs_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoUnidad_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoUnidad_ObtenerPorId(IdTipoUnidad, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }
    }
}
