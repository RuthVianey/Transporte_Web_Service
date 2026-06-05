using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class RentabilidadBussines
    {
        private readonly RentabilidadDAL _dal;

        public RentabilidadBussines(RentabilidadDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<IEnumerable<Entity_Rentabilidad_ListarViajes?>>> Bs_Rentabilidad_ListarViajes(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, 
                                                                                                    DateTime? FechaFin, int? IdCliente, int? IdUnidad, int? IdRuta)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_ListarViajes?>>.Fail("La empresa es obligatoria.");
            }

            if (FechaInicio.HasValue && FechaFin.HasValue && FechaFin < FechaInicio)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_ListarViajes?>>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Rentabilidad_ListarViajes(IdEmpresa, IdSucursal, FechaInicio, FechaFin, IdCliente, IdUnidad, IdRuta);
                                     
            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_ListarViajes?>>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse < IEnumerable<Entity_Rentabilidad_ListarViajes?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Rentabilidad_PorCliente?>>> Bs_Rentabilidad_PorCliente(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio,
                                                                                                    DateTime? FechaFin)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorCliente?>>.Fail("La empresa es obligatoria.");
            }

            if (FechaInicio.HasValue && FechaFin.HasValue && FechaFin < FechaInicio)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorCliente?>>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Rentabilidad_PorCliente(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorCliente?>>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<IEnumerable<Entity_Rentabilidad_PorCliente?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Rentabilidad_PorRuta?>>> Bs_Rentabilidad_PorRuta(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio,
                                                                                                    DateTime? FechaFin)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorRuta?>>.Fail("La empresa es obligatoria.");
            }

            if (FechaInicio.HasValue && FechaFin.HasValue && FechaFin < FechaInicio)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorRuta?>>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Rentabilidad_PorRuta(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorRuta?>>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<IEnumerable<Entity_Rentabilidad_PorRuta?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Rentabilidad_PorUnidad?>>> Bs_Rentabilidad_PorUnidad(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio,
                                                                                                   DateTime? FechaFin)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorUnidad?>>.Fail("La empresa es obligatoria.");
            }

            if (FechaInicio.HasValue && FechaFin.HasValue && FechaFin < FechaInicio)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorUnidad?>>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Rentabilidad_PorUnidad(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_PorUnidad?>>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<IEnumerable<Entity_Rentabilidad_PorUnidad?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Rentabilidad_Viaje?>>> Bs_Rentabilidad_Viaje(int IdViaje, int IdEmpresa)
        {
            if (IdViaje <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_Viaje?>>.Fail("El número del viaje es obligatorio.");
            }

            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_Viaje?>>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Rentabilidad_Viaje(IdViaje, IdEmpresa );

            if (resumen == null)
            {
                return ApiResponse<IEnumerable<Entity_Rentabilidad_Viaje?>>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<IEnumerable<Entity_Rentabilidad_Viaje?>>.Success(resumen);
        }
    }
}
