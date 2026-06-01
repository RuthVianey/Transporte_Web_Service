using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Bussines
{
    public class SeguridadBussines
    {
        private string sBaseDatos;
        private Respuesta resp = new Respuesta();
        private string sPathDescarga = "C:\\inetpub\\wwwroot\\file\\Servicio_Sistema_Gestion_Transporte";
        private string sPathSubida = "C:\\Program Files\\Integra Empresarial\\Sistema_Gestion_Transporte";


        private readonly SeguridadDAL _dal;

        public SeguridadBussines(SeguridadDAL dal)
        {
            _dal = dal;
        }
        public RespuestaApi Bs_Sucursal_Desactivar(int IdSucursal, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Sucursal_Desactivar(IdSucursal, IdEmpresa);

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
        public RespuestaApi Bs_Sucursal_Guardar(int IdSucursal, int IdEmpresa, string Nombre, string NombreCorto, string Codigo, string Calle, string Colonia, string Municipio, string Estado, string CodigoPostal, string Telefono, byte Activo)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Sucursal_Guardar(IdSucursal, IdEmpresa, Nombre, NombreCorto, Codigo, Calle, Colonia, Municipio, Estado, CodigoPostal, Telefono, Activo);

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
        public RespuestaApi Bs_Sucursal_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Sucursal_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

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
        public RespuestaApi Bs_Sucursal_ObtenerPorId(int IdSucursal, int IdEmpresa)
        {
            var resp = new RespuestaApi();

            try
            {
                var listaDatos = _dal.Dal_Sucursal_ObtenerPorId(IdSucursal, IdEmpresa);

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
