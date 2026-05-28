using Transporte_Web_Service.Entity;
using Transporte_Web_Service.Data;

namespace Transporte_Web_Service.Bussines
{
    public class GeneralesBS
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";

        //public GeneralesBS(string sBaseDatos)
        //{
        //    this.sBaseDatos = sBaseDatos;
        //}

        private readonly GeneralesDAC _dac;

        public GeneralesBS(GeneralesDAC dac)
        {
            _dac = dac;
        }

        public RespuestaApi Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo, string sTipoImagen)
        {
            var resp = new RespuestaApi();
            try
            {
                sPathSubida += "\\" + iIdEmpresa.ToString() + "." + sTipoImagen;
                byte[] imageBytes = Convert.FromBase64String(sRutaLogo);
                File.WriteAllBytes(sPathSubida, imageBytes);
                Console.WriteLine("Imagen guardada en: " + sPathSubida);

                var listaDatos = _dac.Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo);

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

        public RespuestaApi Empresa_Desactivar(int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dac.Empresa_Desactivar(iIdEmpresa);

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

        public RespuestaApi Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dac.Empresa_Listar(bSoloActivos, sTextoBusqueda);

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

        public RespuestaApi Empresa_ObtenerPorId(int iIdEmpresa)
        {
            var resp = new RespuestaApi();
            try
            {
                var listaDatos = _dac.Empresa_ObtenerPorId(iIdEmpresa);

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


        //public object Actualizar_Empresa(int iTipo, int iIdEmpresa, string sNombre_Completo, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, string sTipoImagen)
        //{
        //    int? dato = null;
        //    try
        //    {
        //        sPathSubida += "\\" + iIdEmpresa.ToString() + "." + sTipoImagen;
        //        byte[] imageBytes = Convert.FromBase64String(sRutaLogo);
        //        File.WriteAllBytes(sPathSubida, imageBytes);
        //        Console.WriteLine("Imagen guardada en: " + sPathSubida);

        //        dato = _dac.Actualizar_Empresa(iTipo, iIdEmpresa, sNombre_Completo, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sPathSubida);

        //        if (dato != null)
        //        {
        //            resp.setDatos(new { dato });
        //        }
        //        else
        //        {
        //            resp.setEstatus(0);
        //            resp.setMensaje("No se actualizo la informacion.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.setEstatus(-1);
        //        resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
        //    }
        //    return resp.GetRespuestaJSON();
        //}

        //public object Obtienen_Datos_Empresa(int iIdEmpresa)
        //{
        //    List<Obtienen_Datos_Empresa> listaDatos = new List<Obtienen_Datos_Empresa>();
        //    try
        //    {
        //        listaDatos = _dac.Obtienen_Datos_Empresa(iIdEmpresa);

        //        if (listaDatos.Count > 0)
        //        {
        //            if (listaDatos[0].RutaLogo != "" && listaDatos[0].RutaLogo != null)
        //            {
        //                byte[] reporteBytes = System.IO.File.ReadAllBytes(listaDatos[0].RutaLogo);
        //                listaDatos[0].RutaLogo = Convert.ToBase64String(reporteBytes);
        //            }

        //            resp.setDatos(new { listaDatos });
        //        }
        //        else
        //        {
        //            resp.setEstatus(0);
        //            resp.setMensaje("No se actualizo la informacion.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.setEstatus(-1);
        //        resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
        //    }
        //    return resp.GetRespuestaJSON();
        //}
        //public object Obtiene_Empresa_Por_Correo(string sEmail)
        //{
        //    List<Usuarios_Empresa> listaDatos = new List<Usuarios_Empresa>();
        //    try
        //    {
        //        listaDatos = _dac.Obtiene_Empresa_Por_Correo(sEmail);

        //        if (listaDatos.Count > 0)
        //        {
        //            resp.setDatos(new { listaDatos });
        //        }
        //        else
        //        {
        //            resp.setEstatus(0);
        //            resp.setMensaje("No se encontro ninguna empresa.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.setEstatus(-1);
        //        resp.setMensaje("Ocurrio un error al actualizar los datos." + ex.Message);
        //    }
        //    return resp.GetRespuestaJSON();
        //}
    }
}
