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
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("La empresa es obligatoria.");

            if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("La fecha final no puede ser menor a la fecha inicial.");

            var resumen = await _dal.Dal_dashObtenCostoTipo(idEmpresa, idSucursal, fechaInicio, fechaFin );

            if (resumen == null)
                return ApiResponse<Entity_Dashboard_CostosPorTipo>.Fail("No se encontró información del dashboard.");

            return ApiResponse<Entity_Dashboard_CostosPorTipo>.Success(resumen);
        }

        public RespuestaApi Bs_Dashboard_ResumenOperativo(int IdEmpresa, int? IdSucursal, string? FechaInicio, string? FechaFin)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Dashboard_ResumenOperativo_TraeDatos(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    // Pasamos el objeto anónimo directamente, sin serializar a texto todavía
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp; // Regresamos el objeto C# limpio
        }

        public RespuestaApi Bs_Dashboard_RentabilidadMensual(int IdEmpresa, int? IdSucursal, int Anio)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Dal_dashRentaBilidadMensual(IdEmpresa, IdSucursal, Anio);
                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos } ;
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp; // Regresamos el objeto C# limpio
        }

        public RespuestaApi Bs_DashBoard_TopClientes(int IdEmpresa, int? IdSucursal, string? FechaInicio, string? FechaFin)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_dashDashboardTopClientes(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }
            return resp; // Regresamos el objeto C# limpio
        }

        public RespuestaApi Bs_Dashboard_TopUnidades(int IdEmpresa, int? IdSucursal, string? FechaInicio, string? FechaFin)
        { 
            var resp = new RespuestaApi();

            try
            { 
                var listaDatos = _dal.Dal_dashDashboardTopUnidades(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch(Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }
            
            return resp; // Regresamos el objeto C# limpio
        }

        public RespuestaApi Bs_Dashboard_ViajesPorEstado(int IdEmpresa, int? IdSucursal, string? FechaInicio, string? FechaFin)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_dashObtenViajeEstado(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se encontraron datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp; // Regresamos el objeto C# limpio
        }
    }
}

