using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Bussines
{
    public class RolesBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Sistema_Gestion_Transporte";


        private readonly RolesDAL _dal;

        public RolesBussines(RolesDAL dal)
        {
            _dal = dal;
        }

        public RespuestaApi Bs_Rol_Desactivar(int IdRol, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Rol_Desactivar(IdRol, IdEmpresa);

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

        public RespuestaApi Bs_Rol_Guardar(int IdRol, int IdEmpresa, string Nombre, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Rol_Guardar(IdRol, IdEmpresa, Nombre, Activo);

                if (listaDatos != null && listaDatos.Count > 0)
                {
                    resp.Datos = new { listaDatos };
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

        public RespuestaApi Bs_Rol_Listar(int IdEmpresa, byte SoloActivos)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Rol_Listar(IdEmpresa, SoloActivos);

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

        public RespuestaApi Bs_Rol_ObtenerPorId(int IdEmpresa, int IdRol)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Rol_ObtenerPorId(IdEmpresa, IdRol);

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

        public RespuestaApi Bs_RolPrograma_GuardarPermiso(int IdRol, int IdEmpresa, int IdPrograma, byte PuedeLeer, byte PuedeEscribir, byte PuedeEliminar)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RolPrograma_GuardarPermiso(IdRol, IdEmpresa, IdPrograma, PuedeLeer, PuedeEscribir, PuedeEliminar);

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

        public RespuestaApi Bs_RolPrograma_ListarPorRol(int IdEmpresa, int IdRol)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_RolPrograma_ListarPorRol(IdEmpresa, IdRol);

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
