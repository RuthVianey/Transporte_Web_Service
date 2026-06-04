using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class RentabilidadBussines
    {
        //private string sBaseDatos;
        //private Respuesta resp = new Respuesta();
        //private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        //private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly RentabilidadDAL _dal;

        public RentabilidadBussines(RentabilidadDAL dal)
        {
            _dal = dal;
        }

        public async Task<ApiResponse<Entity_Rentabilidad_ListarViajes>> Bs_Rentabilidad_ListarViajes(int IdEmpresa, int? IdSucursal, DateTime? FechaInicio, 
                                                                                                    DateTime? FechaFin, int? IdCliente, int? IdUnidad, int? IdRuta)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_Rentabilidad_ListarViajes>.Fail("La empresa es obligatoria.");
            }

            if (FechaInicio.HasValue && FechaFin.HasValue && FechaFin < FechaInicio)
            {
                return ApiResponse<Entity_Rentabilidad_ListarViajes>.Fail("La fecha final no puede ser menor a la fecha inicial.");
            }

            var resumen = await _dal.Dal_Rentabilidad_ListarViajes(IdEmpresa, IdSucursal, FechaInicio, FechaFin, IdCliente, IdUnidad, IdRuta);
                                     
            if (resumen == null)
            {
                return ApiResponse<Entity_Rentabilidad_ListarViajes>.Fail("No se encontró información del dashboard.");
            }
            return ApiResponse<Entity_Rentabilidad_ListarViajes>.Success(resumen);
        }

    }
}
