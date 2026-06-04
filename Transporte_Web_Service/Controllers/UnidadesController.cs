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

    }
}
