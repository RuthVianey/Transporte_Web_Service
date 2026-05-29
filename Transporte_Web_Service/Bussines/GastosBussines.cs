using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class GastosBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly GastosDAL _dal;

        public GastosBussines(GastosDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_Gasto_Eliminar(int IdGasto, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Gasto_Eliminar(IdGasto, IdEmpresa);

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

        public RespuestaApi Bs_Gasto_Guardar(int IdGasto, int IdEmpresa, int IdSucursal, int IdTipoGasto, int IdViaje, int IdUnidad, string Fecha, decimal Monto, string Referencia, string Descripcion, byte EsFacturable)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Gasto_Guardar(IdGasto, IdEmpresa, IdSucursal, IdTipoGasto, IdViaje, IdUnidad, Fecha, Monto, Referencia, Descripcion, EsFacturable);

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

        public RespuestaApi Bs_Gasto_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Gasto_ListarPorViaje(IdViaje, IdEmpresa);

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

        public RespuestaApi Bs_Gasto_ObtenerPorId(int IdGasto, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Gasto_ObtenerPorId(IdGasto, IdEmpresa);

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
