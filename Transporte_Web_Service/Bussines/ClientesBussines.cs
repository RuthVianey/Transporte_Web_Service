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

        public RespuestaApi Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);

                if (listaDatos.Count > 0)
                {
                    resp.Datos = listaDatos;
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
        public RespuestaApi Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);

                if (listaDatos.Count > 0)
                {
                    resp.Datos = listaDatos;
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
        public RespuestaApi Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            var resp = new RespuestaApi();
            try
            {
                var dato = _dal.Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);

                if (dato != null)
                {
                    resp.Datos = dato;
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
        public RespuestaApi Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Cliente_Desactivar(iIdCliente, iIdEmpresa);

                if (listaDatos.Count > 0)
                {
                    resp.Datos = listaDatos ;
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
