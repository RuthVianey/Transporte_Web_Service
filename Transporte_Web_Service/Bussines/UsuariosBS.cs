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
        public RespuestaApi Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dac.Usuario_Guardar(iIdUsuario, iIdEmpresa, sNombre, sEmail, sContrasenia, iIdSucursal);

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
