using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class UnidadesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly UnidadesDAL _dal;

        public UnidadesBussines(UnidadesDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoUnidad_Desactivar(IdTipoUnidad, IdEmpresa);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se desactivo los datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

        public RespuestaApi Bs_TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoUnidad_Guardar(IdTipoUnidad, IdEmpresa, Descripcion, Activo);

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

        public RespuestaApi Bs_TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoUnidad_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

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

        public RespuestaApi Bs_TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoUnidad_ObtenerPorId(IdTipoUnidad, IdEmpresa);

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
