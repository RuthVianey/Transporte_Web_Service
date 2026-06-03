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

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Sucursal_Desactivar(int IdSucursal, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Sucursal_Desactivar(IdSucursal, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Sucursal_Guardar(int IdSucursal, int IdEmpresa, string Nombre, string NombreCorto, string Codigo, string Calle, string Colonia, string Municipio, string Estado, string CodigoPostal, string Telefono, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Sucursal_Guardar(IdSucursal, IdEmpresa, Nombre, NombreCorto, Codigo, Calle, Colonia, Municipio, Estado, CodigoPostal, Telefono, Activo);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Sucursal_Listar>> Bs_Sucursal_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_Sucursal_Listar>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Sucursal_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resumen == null)
            {
                return ApiResponse<Entity_Sucursal_Listar>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Sucursal_Listar>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Sucursal_Listar>> Bs_Sucursal_ObtenerPorId(int IdSucursal, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_Sucursal_Listar>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Sucursal_ObtenerPorId(IdSucursal, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<Entity_Sucursal_Listar>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Sucursal_Listar>.Success(resumen);
        }
    }
}
