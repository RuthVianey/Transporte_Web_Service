using Microsoft.Extensions.Hosting;
using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class MantenimientoBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly MantenimientoDAL _dal;

        public MantenimientoBussines(MantenimientoDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_Mantenimiento_Eliminar(int IdMantenimiento, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Mantenimiento_Eliminar(IdMantenimiento, IdEmpresa);

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

        public RespuestaApi Bs_Mantenimiento_Guardar(int IdMantenimiento, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, int IdTipoMantenimiento, string Fecha, decimal KmUnidad, string Descripcion, decimal Costo, byte EsAsignableAViaje)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Mantenimiento_Guardar(IdMantenimiento, IdEmpresa, IdSucursal, IdUnidad, IdViaje, IdTipoMantenimiento, Fecha, KmUnidad, Descripcion, Costo, EsAsignableAViaje);

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

        public RespuestaApi Bs_Mantenimiento_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Mantenimiento_ListarPorViaje(IdViaje, IdEmpresa);

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

        public RespuestaApi Bs_Mantenimiento_ObtenerPorId(int IdMantenimiento, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Mantenimiento_ObtenerPorId(IdMantenimiento, IdEmpresa);

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

        public RespuestaApi Bs_MantenimientoConcepto_Desactivar(int IdConcepto, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoConcepto_Desactivar(IdConcepto, IdEmpresa);

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

        public RespuestaApi Bs_MantenimientoConcepto_Guardar(int IdConcepto, int IdEmpresa, string Descripcion, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoConcepto_Guardar(IdConcepto, IdEmpresa, Descripcion, Activo);

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

        public RespuestaApi Bs_MantenimientoConcepto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoConcepto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

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

        public RespuestaApi Bs_MantenimientoConcepto_ObtenerPorId(int IdConcepto, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoConcepto_ObtenerPorId(IdConcepto, IdEmpresa);

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

        public RespuestaApi Bs_MantenimientoDetalle_Eliminar(int IdDetalle, int IdMantenimiento)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoDetalle_Eliminar(IdDetalle, IdMantenimiento);

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

        public RespuestaApi Bs_MantenimientoDetalle_Guardar(int IdDetalle, int IdMantenimiento, int IdConcepto, decimal Cantidad, decimal CostoUnitario)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoDetalle_Guardar(IdDetalle, IdMantenimiento, IdConcepto, Cantidad, CostoUnitario);

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

        public RespuestaApi Bs_MantenimientoDetalle_Listar(int IdMantenimiento)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_MantenimientoDetalle_Listar(IdMantenimiento);

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
        public RespuestaApi Bs_TipoMantenimiento_Desactivar(int IdTipoMantenimiento, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoMantenimiento_Desactivar(IdTipoMantenimiento, IdEmpresa);

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
        public RespuestaApi Bs_TipoMantenimiento_Guardar(int IdTipoMantenimiento, int IdEmpresa, string Descripcion, byte EsPreventivo, byte EsCorrectivo, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoMantenimiento_Guardar(IdTipoMantenimiento, IdEmpresa, Descripcion, EsPreventivo, EsCorrectivo, Activo);

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
        public RespuestaApi Bs_TipoMantenimiento_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoMantenimiento_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

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
        public RespuestaApi Bs_TipoMantenimiento_ObtenerPorId(int IdTipoMantenimiento, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_TipoMantenimiento_ObtenerPorId(IdTipoMantenimiento, IdEmpresa);

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
