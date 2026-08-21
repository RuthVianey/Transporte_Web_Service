using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly UnidadesBussines _bs;

        public UnidadesController(UnidadesBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_TipoUnidad_Desactivar")]
        public async Task<IActionResult> TipoUnidad_Desactivar([FromQuery] int IdTipoUnidad, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoUnidad_Desactivar(IdTipoUnidad, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoUnidad_Guardar")]
        public async Task<IActionResult> TipoUnidad_Guardar([FromQuery] int IdTipoUnidad, [FromQuery] int IdEmpresa, [FromQuery] string Descripcion, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_TipoUnidad_Guardar(IdTipoUnidad, IdEmpresa, Descripcion, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoUnidad_Listar")]
        public async Task<IActionResult> TipoUnidad_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_TipoUnidad_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoUnidad_ObtenerPorId")]
        public async Task<IActionResult> TipoUnidad_ObtenerPorId([FromQuery] int IdTipoUnidad, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoUnidad_ObtenerPorId(IdTipoUnidad, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpGet("listaDatos_Unidad_Desactivar")]
        public async Task<IActionResult> Unidad_Desactivar([FromQuery] int IdUnidad, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Unidad_Desactivar(IdUnidad, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Unidad_Guardar")]
        public async Task<IActionResult> Unidad_Guardar([FromQuery] int IdUnidad, [FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] int IdTipoUnidad, [FromQuery] string? NumeroEconomico, [FromQuery] string Placas, [FromQuery] string? Marca, [FromQuery] string? Modelo, [FromQuery] int? Anio, [FromQuery] decimal? CapacidadLitros, [FromQuery] decimal? CapacidadKg, [FromQuery] decimal? OdometroActual, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_Unidad_Guardar(IdUnidad, IdEmpresa, IdSucursal, IdTipoUnidad, NumeroEconomico, Placas, Marca, Modelo, Anio, CapacidadLitros, CapacidadKg, OdometroActual, Activo);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Unidad_Listar")]
        public async Task<IActionResult> Unidad_Listar([FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] byte SoloActivos, [FromQuery] string? TextoBusqueda)
        {
            var response = await _bs.Bs_Unidad_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Unidad_ObtenerPorId")]
        public async Task<IActionResult> Unidad_ObtenerPorId([FromQuery] int IdUnidad, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Unidad_ObtenerPorId(IdUnidad, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
    }
}

