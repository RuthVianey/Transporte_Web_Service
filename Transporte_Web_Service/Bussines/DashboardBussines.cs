using System.Runtime.InteropServices.ObjectiveC;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;


namespace Transporte_Web_Service.Bussines
{
    
    public class DashboardBussines
    {
        //private string sBaseDatos;
        //private Respuesta resp = new Respuesta();
        //private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        //private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly DashboardDAL _dal;
        
        public DashboardBussines(DashboardDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<Entity_Dashboard_CostosPorTipo>> Bs_Dashboard_CostosPorTipo(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (idEmpresa <= 0)
            { 
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("La empresa es obligatoria.");
            }

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
            {
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_dashObtenCostoTipo(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (resumen == null)
            { 
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_CostosPorTipo>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Dashboard_ResumenOperativo>> Bs_Dashboard_ResumenOperativo(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (idEmpresa <= 0)
            {
                return ApiResponse<Entity_Dashboard_ResumenOperativo>.Fail("La empresa es obligatoria.");
            }

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
            {
                return ApiResponse<Entity_Dashboard_ResumenOperativo>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Dashboard_ResumenOperativo(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (resumen == null)
            {
                return ApiResponse<Entity_Dashboard_ResumenOperativo>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_ResumenOperativo>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Dashboard_RentabilidadMensual>> Bs_Dashboard_RentabilidadMensual(int idEmpresa, int? idSucursal, int anio)
        {
           
            var resumen = await _dal.Dal_Dashboard_RentabilidadMensual(idEmpresa, idSucursal, anio);

            if (resumen == null)
            {
                return ApiResponse<Entity_Dashboard_RentabilidadMensual>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_RentabilidadMensual>.Success(resumen);
        }


        public async Task<ApiResponse<Entity_Dashboard_TopClientes>> Bs_DashBoard_TopClientes(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (idEmpresa <= 0)
            {
                return ApiResponse<Entity_Dashboard_TopClientes>.Fail("La empresa es obligatoria.");
            }

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
            {
                return ApiResponse<Entity_Dashboard_TopClientes>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Dashboard_TopClientes(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (resumen == null)
            {
                return ApiResponse<Entity_Dashboard_TopClientes>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_TopClientes>.Success(resumen);
        }


        public async Task<ApiResponse<Entity_Dashboard_TopUnidades>> Dal_dashDashboardTopUnidades(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (idEmpresa <= 0)
            {
                return ApiResponse<Entity_Dashboard_TopUnidades>.Fail("La empresa es obligatoria.");
            }

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
            {
                return ApiResponse<Entity_Dashboard_TopUnidades>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_dashDashboardTopUnidades(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (resumen == null)
            {
                return ApiResponse<Entity_Dashboard_TopUnidades>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_TopUnidades>.Success(resumen);
        }


        public async Task<ApiResponse<Entity_Dashboard_ViajesPorEstado>> Bs_Dashboard_ViajesPorEstado(int idEmpresa, int? idSucursal, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (idEmpresa <= 0)
            {
                return ApiResponse<Entity_Dashboard_ViajesPorEstado>.Fail("La empresa es obligatoria.");
            }

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
            {
                return ApiResponse<Entity_Dashboard_ViajesPorEstado>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_dashObtenViajeEstado(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (resumen == null)
            {
                return ApiResponse<Entity_Dashboard_ViajesPorEstado>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Dashboard_ViajesPorEstado>.Success(resumen);
        }

    }
}

