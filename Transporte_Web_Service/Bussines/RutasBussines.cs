using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class RutasBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly RutasDAL _dal;

        public RutasBussines(RutasDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_Ruta_Desactivar(int IdRuta, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Ruta_Desactivar(IdRuta, IdEmpresa);

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

        public RespuestaApi Bs_Ruta_Guardar(int IdRuta, int IdEmpresa, int IdSucursal, string Nombre, string Origen, string Destino, decimal DistanciaKm, int TiempoEstimadoMin, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Ruta_Guardar(IdRuta, IdEmpresa, IdSucursal, Nombre, Origen, Destino, DistanciaKm, TiempoEstimadoMin, Activo);

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

        public RespuestaApi Bs_Ruta_Listar(int IdEmpresa, int IdSucursal, byte SoloActivos, string TextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Ruta_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);

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

        public RespuestaApi Bs_Ruta_ObtenerPorId(int IdRuta, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Ruta_ObtenerPorId(IdRuta, IdEmpresa);

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

        public RespuestaApi Bs_RutaDetalle_Eliminar(int IdRutaDetalle, int IdRuta)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RutaDetalle_Eliminar(IdRutaDetalle, IdRuta);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
                }
                else
                {
                    resp.Estatus = 0;
                    resp.Mensaje = "No se eliminaron los datos.";
                }
            }
            catch (Exception ex)
            {
                resp.Estatus = -1;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

        public RespuestaApi Bs_RutaDetalle_Guardar(int IdRutaDetalle, int IdRuta, int Orden, string Punto, decimal Latitud, decimal Longitud, string Tipo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RutaDetalle_Guardar(IdRutaDetalle, IdRuta, Orden, Punto, Latitud, Longitud, Tipo);

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

        public RespuestaApi Bs_RutaDetalle_Listar(int IdRuta)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RutaDetalle_Listar(IdRuta);

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

        public RespuestaApi Bs_RutaDetalle_ObtenerPorId(int IdRutaDetalle, int IdRuta)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RutaDetalle_ObtenerPorId(IdRutaDetalle, IdRuta);

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
