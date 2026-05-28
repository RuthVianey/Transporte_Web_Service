using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class UsuariosBS
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";

        private readonly UsuariosDAC _dac;

        public UsuariosBS(UsuariosDAC dac)
        {
            _dac = dac;
        }

        /*COMIENZA USUARIO*/
        public object Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {
            List<RespuestaGeneral> listaDatos = new List<RespuestaGeneral>();
            try
            {
                listaDatos = _dac.Usuario_Guardar(iIdUsuario, iIdEmpresa, sNombre, sEmail, sContrasenia, iIdSucursal);

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
