using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ViajesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly ViajesDAL _dal;

        public ViajesBussines(ViajesDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_EstadoViaje_Guardar(IdEstadoViaje, Descripcion);

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

            return resp;
        }

        public RespuestaApi Bs_EstadoViaje_Listar()
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_EstadoViaje_Listar();

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

            return resp;
        }

        public RespuestaApi Bs_EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_EstadoViaje_ObtenerPorId(IdEstadoViaje);

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

            return resp;
        }

    }
}
