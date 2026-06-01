using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RolesBussines _bs;

        public RolesController(RolesBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Rol_Desactivar")]
        public IActionResult Rol_Desactivar(int IdRol, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Rol_Desactivar(IdRol, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Rol_Guardar")]
        public IActionResult Rol_Guardar(int IdRol, int IdEmpresa, string Nombre, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_Rol_Guardar(IdRol, IdEmpresa, Nombre, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Rol_Listar")]
        public IActionResult Rol_Listar(int IdEmpresa, byte SoloActivos)
        {
            RespuestaApi resultado = _bs.Bs_Rol_Listar(IdEmpresa, SoloActivos);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Rol_ObtenerPorId")]
        public IActionResult Rol_ObtenerPorId(int IdEmpresa, int IdRol)
        {
            RespuestaApi resultado = _bs.Bs_Rol_ObtenerPorId(IdEmpresa, IdRol);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RolPrograma_GuardarPermiso")]
        public IActionResult RolPrograma_GuardarPermiso(int IdRol, int IdEmpresa, int IdPrograma, byte PuedeLeer, byte PuedeEscribir, byte PuedeEliminar)
        {
            RespuestaApi resultado = _bs.Bs_RolPrograma_GuardarPermiso(IdRol, IdEmpresa, IdPrograma, PuedeLeer, PuedeEscribir, PuedeEliminar);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RolPrograma_ListarPorRol")]
        public IActionResult RolPrograma_ListarPorRol(int IdEmpresa, int IdRol)
        {
            RespuestaApi resultado = _bs.Bs_RolPrograma_ListarPorRol(IdEmpresa, IdRol);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
