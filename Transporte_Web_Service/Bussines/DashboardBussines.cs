using System.Runtime.InteropServices.ObjectiveC;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    
    public class DashboardBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly DashboardDAL _dal;

        public DashboardBussines(DashboardDAL dal)
        {
            _dal = dal;
        }

        // Cambiamos el tipo de retorno de 'object' a nuestra clase de respuesta estructurada
        public RespuestaApi Bs_Dashboard_CostosPorTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_dashObtenCostoTipo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

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

        public RespuestaApi Bs_Dashboard_ResumenOperativo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
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

        public RespuestaApi Bs_Dashboard_RentabilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
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

        public RespuestaApi Bs_DashBoard_TopClientes(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
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
        

        public RespuestaApi Bs_Dashboard_ViajesPorEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
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

