using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class AuthBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";

        
        private readonly AuthDAL _dal;

        public AuthBussines(AuthDAL dal)
        {
            _dal = dal;
        }

        public object Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            int? dato = 0;
            try
            {
                dato = _dal.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);

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

        public object Usuarios_Empresa(int iIdEmpresa)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                listaDatos = _dal.Usuarios_Empresa(iIdEmpresa);

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
