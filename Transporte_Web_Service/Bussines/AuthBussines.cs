using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class AuthBussines
    {
        private string sBaseDatos;
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";

        
        private readonly AuthDAL _dal;

        public AuthBussines(AuthDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            var resp = new RespuestaApi();
            try
            {
                var dato = _dal.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);

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

        public RespuestaApi Usuarios_Empresa(int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Usuarios_Empresa(iIdEmpresa);

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
    }
}
