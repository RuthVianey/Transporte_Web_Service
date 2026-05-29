using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class OperadoresBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly OperadoresDAL _dal;

        public OperadoresBussines(OperadoresDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Operador_Desactivar(iIdOperador, iIdEmpresa);

                if (listaDatos.Count > 0)
                {
                    resp.Datos = listaDatos;
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se desactivo el operador.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }
            return resp;
        }

        public RespuestaApi Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);

                if (listaDatos.Count > 0)
                {
                    resp.Datos = listaDatos;
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se guardaros los datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }
            return resp;
        }

        public RespuestaApi Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);

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
        public RespuestaApi Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dal.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);

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
