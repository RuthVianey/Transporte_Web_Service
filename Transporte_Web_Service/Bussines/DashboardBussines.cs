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

        public object Dashboard_CostosPorTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Dashboard_CostosPorTipo> listaDatos = new List<Dashboard_CostosPorTipo>();

            try
            {
                listaDatos = _dal.dashObtenCostoTipo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

                if (listaDatos.Count > 0)
                {
                    resp.setDatos(new { listaDatos });
                }
                else
                {
                    resp.setEstatus(0);
                    resp.setMensaje("No se encontraron datos.");
                }
            }
            catch (Exception ex)
            {
                resp.setEstatus(-1);
                resp.setMensaje(ex.Message);
            }
            return resp.GetRespuestaJSON();
        }

        public Object Dashboard_RentabilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
        {
            List<Dasboard_RentabilidadMensual> listaDatos = new List<Dasboard_RentabilidadMensual>();
            try
            {
                listaDatos = _dal.dashRentaBilidadMensual(IdEmpresa, IdSucursal, Anio);
                if (listaDatos.Count > 0)
                {
                    resp.setDatos(new { listaDatos });
                }
                else
                {
                    resp.setEstatus(0);
                    resp.setMensaje("No se encontraron datos.");
                }
            }
            catch (Exception ex)
            {
                resp.setEstatus(-1);
                resp.setMensaje(ex.Message);
            }
            return resp.GetRespuestaJSON();
        }

        public object Dashboard_ViajesPorEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            List<Dashboard_ViajesPorEstado> listaDatos = new List<Dashboard_ViajesPorEstado>();

            try
            {
                listaDatos = _dal.dashObtenViajeEstado(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

                if (listaDatos.Count > 0)
                {
                    resp.setDatos(new { listaDatos });
                }
                else
                {
                    resp.setEstatus(0);
                    resp.setMensaje("No se actualizo la informacion.");
                }
            }
            catch (Exception ex)
            {
                resp.setEstatus(-1);
                resp.setMensaje(ex.Message);
            }
            return resp.GetRespuestaJSON();
        }
    }
}

