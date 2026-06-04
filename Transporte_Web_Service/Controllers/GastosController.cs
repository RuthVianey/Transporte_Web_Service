using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly GastosBussines _bs;

        public GastosController(GastosBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Gasto_Eliminar")]
        public async Task<IActionResult> Gasto_Eliminar([FromQuery] int IdGasto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Gasto_Eliminar(IdGasto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Gasto_Guardar")]
        public async Task<IActionResult> Gasto_Guardar([FromQuery] int IdGasto, [FromQuery] int IdEmpresa, [FromQuery] int IdSucursal, [FromQuery] int IdTipoGasto, [FromQuery] int IdViaje, [FromQuery] int IdUnidad, [FromQuery] string Fecha, [FromQuery] decimal Monto, [FromQuery] string Referencia, [FromQuery] string Descripcion, [FromQuery] byte EsFacturable)
        {
            var response = await _bs.Bs_Gasto_Guardar(IdGasto, IdEmpresa, IdSucursal, IdTipoGasto, IdViaje, IdUnidad, Fecha, Monto, Referencia, Descripcion, EsFacturable);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Gasto_ListarPorViaje")]
        public async Task<IActionResult> Gasto_ListarPorViaje([FromQuery] int IdViaje, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Gasto_ListarPorViaje(IdViaje, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Gasto_ObtenerPorId")]
        public async Task<IActionResult> Gasto_ObtenerPorId([FromQuery] int IdGasto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Gasto_ObtenerPorId(IdGasto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoGasto_Desactivar")]
        public async Task<IActionResult> TipoGasto_Desactivar([FromQuery] int IdTipoGasto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoGasto_Desactivar(IdTipoGasto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoGasto_Guardar")]
        public async Task<IActionResult> TipoGasto_Guardar([FromQuery] int IdTipoGasto, [FromQuery] int IdEmpresa, [FromQuery] string Descripcion, [FromQuery] byte EsCostoDirecto, [FromQuery] byte EsMantenimiento, [FromQuery] byte EsCombustible, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_TipoGasto_Guardar(IdTipoGasto, IdEmpresa, Descripcion, EsCostoDirecto, EsMantenimiento, EsCombustible, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoGasto_Listar")]
        public async Task<IActionResult> TipoGasto_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_TipoGasto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoGasto_ObtenerPorId")]
        public async Task<IActionResult> TipoGasto_ObtenerPorId([FromQuery] int IdTipoGasto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoGasto_ObtenerPorId(IdTipoGasto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
