using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class OperadoresBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly OperadoresDAL _dal;

        public OperadoresBussines(OperadoresDAL dal)
        {
            _dal = dal;
        }

        public object Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            List<Operador_ObtenerPorId> listaDatos = new List<Operador_ObtenerPorId>();
            try
            {
                listaDatos = _dal.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);

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
                resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
            }
            return resp.GetRespuestaJSON();
        }

        public object Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            List<Operador_ObtenerPorId> listaDatos = new List<Operador_ObtenerPorId>();
            try
            {
                listaDatos = _dal.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);

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
                resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
            }
            return resp.GetRespuestaJSON();
        }

        public object Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                listaDatos = _dal.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);

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
                resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
            }
            return resp.GetRespuestaJSON();
        }

        public object Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                listaDatos = _dal.Operador_Desactivar(iIdOperador, iIdEmpresa);

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
                resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
            }
            return resp.GetRespuestaJSON();
        }
    }
}
