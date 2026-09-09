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
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdTipoUnidad <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El tipo de unidad es obligatorio.");

            var resumen = await _dal.Dal_TipoUnidad_Desactivar(IdTipoUnidad, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (string.IsNullOrWhiteSpace(Descripcion)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La descripcion es obligatoria.");

            var resumen = await _dal.Dal_TipoUnidad_Guardar(IdTipoUnidad, IdEmpresa, Descripcion, Activo);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardo la informacion.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>> Bs_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("La empresa es obligatoria.");

            var resumen = await _dal.Dal_TipoUnidad_Listar(IdEmpresa, SoloActivos, TextoBusqueda);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>> Bs_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("La empresa es obligatoria.");
            if (IdTipoUnidad <= 0) return ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("El tipo de unidad es obligatorio.");

            var resumen = await _dal.Dal_TipoUnidad_ObtenerPorId(IdTipoUnidad, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_TipoUnidad_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Unidad_Desactivar(int IdUnidad, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdUnidad <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La unidad es obligatoria.");

            var resumen = await _dal.Dal_Unidad_Desactivar(IdUnidad, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Unidad_Guardar(int IdUnidad, int IdEmpresa, int? IdSucursal, int IdTipoUnidad, string? NumeroEconomico, string Placas, string? Marca, string? Modelo, int? Anio, decimal? CapacidadLitros, decimal? CapacidadKg, decimal? OdometroActual, byte Activo)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdTipoUnidad <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El tipo de unidad es obligatorio.");
            if (string.IsNullOrWhiteSpace(Placas)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Las placas son obligatorias.");

            var resumen = await _dal.Dal_Unidad_Guardar(IdUnidad, IdEmpresa, IdSucursal, IdTipoUnidad, NumeroEconomico, Placas, Marca, Modelo, Anio, CapacidadLitros, CapacidadKg, OdometroActual, Activo);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardo la informacion.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Unidad_Listar?>>> Bs_Unidad_Listar(int IdEmpresa, int? IdSucursal, byte SoloActivos, string? TextoBusqueda)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Fail("La empresa es obligatoria.");

            var resumen = await _dal.Dal_Unidad_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Unidad_Listar?>>> Bs_Unidad_ObtenerPorId(int IdUnidad, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Fail("La empresa es obligatoria.");
            if (IdUnidad <= 0) return ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Fail("La unidad es obligatoria.");

            var resumen = await _dal.Dal_Unidad_ObtenerPorId(IdUnidad, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Fail("No se encontro informacion.")
                : ApiResponse<IEnumerable<Entity_Unidad_Listar?>>.Success(resumen);
        }
        public async Task<ApiResponse<IEnumerable<Entity_UnidadDisponible?>>> Bs_Unidad_Disponibilidad_Listar(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin, int? idViajeExcluir)
        {
            if (idEmpresa <= 0) return ApiResponse<IEnumerable<Entity_UnidadDisponible?>>.Fail("La empresa es obligatoria.");
            return ApiResponse<IEnumerable<Entity_UnidadDisponible?>>.Success(await _dal.Dal_Unidad_Disponibilidad_Listar(idEmpresa, idSucursal, fechaInicio, fechaFin, idViajeExcluir));
        }
    }
}
