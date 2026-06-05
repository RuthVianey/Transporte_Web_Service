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
        public async Task<IActionResult> Rol_Desactivar([FromQuery] int IdRol, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Rol_Desactivar(IdRol, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Rol_Guardar")]
        public async Task<IActionResult> Rol_Guardar([FromQuery] int IdRol, [FromQuery] int IdEmpresa, [FromQuery] string Nombre, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_Rol_Guardar(IdRol, IdEmpresa, Nombre, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Rol_Listar")]
        public async Task<IActionResult> Rol_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos)
        {
            var response = await _bs.Bs_Rol_Listar(IdEmpresa, SoloActivos);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Rol_ObtenerPorId")]
        public async Task<IActionResult> Rol_ObtenerPorId([FromQuery] int IdEmpresa, [FromQuery] int IdRol)
        {
            var response = await _bs.Bs_Rol_ObtenerPorId(IdEmpresa, IdRol);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RolPrograma_GuardarPermiso")]
        public async Task<IActionResult> RolPrograma_GuardarPermiso([FromQuery] int IdRol, [FromQuery] int IdEmpresa, [FromQuery] int IdPrograma, [FromQuery] byte PuedeLeer, [FromQuery] byte PuedeEscribir, [FromQuery] byte PuedeEliminar)
        {
            var response = await _bs.Bs_RolPrograma_GuardarPermiso(IdRol, IdEmpresa, IdPrograma, PuedeLeer, PuedeEscribir, PuedeEliminar);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RolPrograma_ListarPorRol")]
        public async Task<IActionResult> RolPrograma_ListarPorRol([FromQuery] int IdEmpresa, [FromQuery] int IdRol)
        {
            var response = await _bs.Bs_RolPrograma_ListarPorRol(IdEmpresa, IdRol);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
