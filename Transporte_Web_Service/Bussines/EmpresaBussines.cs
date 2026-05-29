using System.Runtime.InteropServices.ObjectiveC;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class EmpresaBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";

        private readonly EmpresaDAL _dal;

        public EmpresaBussines(EmpresaDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_Empresa_Desactivar(int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Empresa_Desactivar(IdEmpresa);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se desactivo la empresa.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

        public RespuestaApi Bs_Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se guardaron los datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp; 
        }

        public RespuestaApi Bs_Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Empresa_Listar(bSoloActivos, sTextoBusqueda);

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

            return resp; // Regresamos el objeto C# limpio
        }

        public RespuestaApi Bs_Empresa_ObtenerPorId(int iIdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Empresa_ObtenerPorId(iIdEmpresa);

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
