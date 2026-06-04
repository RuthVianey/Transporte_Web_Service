using Microsoft.Extensions.Hosting;
using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class MantenimientoBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly MantenimientoDAL _dal;

        public MantenimientoBussines(MantenimientoDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Mantenimiento_Eliminar(int IdMantenimiento, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Mantenimiento_Eliminar(IdMantenimiento, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_Mantenimiento_Guardar(int IdMantenimiento, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, int IdTipoMantenimiento, string Fecha, decimal KmUnidad, string Descripcion, decimal Costo, byte EsAsignableAViaje)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Mantenimiento_Guardar(IdMantenimiento, IdEmpresa, IdSucursal, IdUnidad, IdViaje, IdTipoMantenimiento, Fecha, KmUnidad, Descripcion, Costo, EsAsignableAViaje);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Mantenimiento_ListarPorViaje?>>> Bs_Mantenimiento_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Mantenimiento_ListarPorViaje?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Mantenimiento_ListarPorViaje(IdViaje, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Mantenimiento_ListarPorViaje?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Mantenimiento_ListarPorViaje?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Mantenimiento_ObtenerPorId?>>> Bs_Mantenimiento_ObtenerPorId(int IdMantenimiento, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Mantenimiento_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Mantenimiento_ObtenerPorId(IdMantenimiento, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Mantenimiento_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_Mantenimiento_ObtenerPorId?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_MantenimientoConcepto_Desactivar(int IdConcepto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_MantenimientoConcepto_Desactivar(IdConcepto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_MantenimientoConcepto_Guardar(int IdConcepto, int IdEmpresa, string Descripcion, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_MantenimientoConcepto_Guardar(IdConcepto, IdEmpresa, Descripcion, Activo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>> Bs_MantenimientoConcepto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_MantenimientoConcepto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>> Bs_MantenimientoConcepto_ObtenerPorId(int IdConcepto, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_MantenimientoConcepto_ObtenerPorId(IdConcepto, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_MantenimientoConcepto_ObtenerPorId?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_MantenimientoDetalle_Eliminar(int IdDetalle, int IdMantenimiento)
        {
            var resumen = await _dal.Dal_MantenimientoDetalle_Eliminar(IdDetalle, IdMantenimiento);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }
        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_MantenimientoDetalle_Guardar(int IdDetalle, int IdMantenimiento, int IdConcepto, decimal Cantidad, decimal CostoUnitario)
        {
            var resumen = await _dal.Dal_MantenimientoDetalle_Guardar(IdDetalle, IdMantenimiento, IdConcepto, Cantidad, CostoUnitario);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_MantenimientoDetalle_Listar?>>> Bs_MantenimientoDetalle_Listar(int IdMantenimiento)
        {
            var resumen = await _dal.Dal_MantenimientoDetalle_Listar(IdMantenimiento);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_MantenimientoDetalle_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_MantenimientoDetalle_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoMantenimiento_Desactivar(int IdTipoMantenimiento, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoMantenimiento_Desactivar(IdTipoMantenimiento, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoMantenimiento_Guardar(int IdTipoMantenimiento, int IdEmpresa, string Descripcion, byte EsPreventivo, byte EsCorrectivo, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoMantenimiento_Guardar(IdTipoMantenimiento, IdEmpresa, Descripcion, EsPreventivo, EsCorrectivo, Activo);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>> Bs_TipoMantenimiento_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoMantenimiento_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>> Bs_TipoMantenimiento_ObtenerPorId(int IdTipoMantenimiento, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_TipoMantenimiento_ObtenerPorId(IdTipoMantenimiento, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Fail("No se encontró información.");
            }
            return ApiResponse<IEnumerable<Entity_TipoMantenimiento_Listar?>>.Success(resumen);
        }
    }
}
