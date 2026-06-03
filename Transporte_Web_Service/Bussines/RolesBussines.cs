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

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Rol_Desactivar(int IdRol, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Rol_Desactivar(IdRol, IdEmpresa);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_Rol_Guardar(int IdRol, int IdEmpresa, string Nombre, byte Activo)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Rol_Guardar(IdRol, IdEmpresa, Nombre, Activo);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Listar_Roles>> Bs_Rol_Listar(int IdEmpresa, byte SoloActivos)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_Listar_Roles>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Rol_Listar(IdEmpresa, SoloActivos);

            if (resumen == null)
            {
                return ApiResponse<Entity_Listar_Roles>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Listar_Roles>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_Listar_Roles>> Bs_Rol_ObtenerPorId(int IdEmpresa, int IdRol)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_Listar_Roles>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_Rol_ObtenerPorId(IdEmpresa, IdRol);

            if (resumen == null)
            {
                return ApiResponse<Entity_Listar_Roles>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_Listar_Roles>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_RespuestaGeneral>> Bs_RolPrograma_GuardarPermiso(int IdRol, int IdEmpresa, int IdPrograma, byte PuedeLeer, byte PuedeEscribir, byte PuedeEliminar)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_RolPrograma_GuardarPermiso(IdRol, IdEmpresa, IdPrograma, PuedeLeer, PuedeEscribir, PuedeEliminar);

            if (resumen == null)
            {
                return ApiResponse<Entity_RespuestaGeneral>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RespuestaGeneral>.Success(resumen);
        }

        public async Task<ApiResponse<Entity_RolPrograma_ListarPorRol>> Bs_RolPrograma_ListarPorRol(int IdEmpresa, int IdRol)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_RolPrograma_ListarPorRol>.Fail("La empresa es obligatoria.");
            }

            var resumen = await _dal.Dal_RolPrograma_ListarPorRol(IdEmpresa, IdRol);

            if (resumen == null)
            {
                return ApiResponse<Entity_RolPrograma_ListarPorRol>.Fail("No se encontró información.");
            }
            return ApiResponse<Entity_RolPrograma_ListarPorRol>.Success(resumen);
        }
    }
}
