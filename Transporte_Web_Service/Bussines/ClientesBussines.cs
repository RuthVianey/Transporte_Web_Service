using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ClientesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly ClientesDAL _dal;

        public ClientesBussines(ClientesDAL dal)
        {
            _dal = dal;
        }

        public object Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            List<Obtener_Cliente_PorId> listaDatos = new List<Obtener_Cliente_PorId>();
            try
            {
                listaDatos = _dal.Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);

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
        public object Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            List<Obtener_Cliente_PorId> listaDatos = new List<Obtener_Cliente_PorId>();
            try
            {
                listaDatos = _dal.Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);

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
        public object Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            int? dato = 0;
            try
            {
                dato = _dal.Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);

                if (dato != null)
                {
                    resp.setDatos(new { dato });
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
        public object Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                listaDatos = _dal.Cliente_Desactivar(iIdCliente, iIdEmpresa);

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
