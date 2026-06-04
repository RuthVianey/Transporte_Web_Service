using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Transporte_Web_Service.Entity.Respuesta;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly SeguridadBussines _bs;

        public SucursalController(SeguridadBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Sucursal_Desactivar")]
        public async Task<IActionResult> Sucursal_Desactivar([FromQuery] int IdSucursal, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Sucursal_Desactivar(IdSucursal, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Sucursal_Guardar")]
        public async Task<IActionResult> Sucursal_Guardar([FromQuery] int IdSucursal, [FromQuery] int IdEmpresa, [FromQuery] string Nombre, [FromQuery] string NombreCorto, [FromQuery] string Codigo, [FromQuery] string Calle, [FromQuery] string Colonia, [FromQuery] string Municipio, [FromQuery] string Estado, [FromQuery] string CodigoPostal, [FromQuery] string Telefono, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_Sucursal_Guardar(IdSucursal, IdEmpresa, Nombre, NombreCorto, Codigo, Calle, Colonia, Municipio, Estado, CodigoPostal, Telefono, Activo);
            
            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Sucursal_Listar")]
        public async Task<IActionResult> Sucursal_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_Sucursal_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Sucursal_ObtenerPorId")]
        public async Task<IActionResult> Sucursal_ObtenerPorId([FromQuery] int IdSucursal, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Sucursal_ObtenerPorId(IdSucursal, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
