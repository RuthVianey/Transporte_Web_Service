using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoBussines _bs;

        public MantenimientoController(MantenimientoBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Mantenimiento_Eliminar")]
        public async Task<IActionResult> Mantenimiento_Eliminar([FromQuery] int IdMantenimiento, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Mantenimiento_Eliminar(IdMantenimiento, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Mantenimiento_Guardar")]
        public async Task<IActionResult> Mantenimiento_Guardar([FromQuery] int IdMantenimiento, [FromQuery] int IdEmpresa, [FromQuery] int IdSucursal, [FromQuery] int IdUnidad, [FromQuery] int IdViaje, [FromQuery] int IdTipoMantenimiento, [FromQuery] string Fecha, [FromQuery] decimal KmUnidad, [FromQuery] string Descripcion, [FromQuery] decimal Costo, [FromQuery] byte EsAsignableAViaje)
        {
            var response = await _bs.Bs_Mantenimiento_Guardar(IdMantenimiento, IdEmpresa, IdSucursal, IdUnidad, IdViaje, IdTipoMantenimiento, Fecha, KmUnidad, Descripcion, Costo, EsAsignableAViaje);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Mantenimiento_ListarPorViaje")]
        public async Task<IActionResult> Mantenimiento_ListarPorViaje([FromQuery] int IdViaje, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Mantenimiento_ListarPorViaje(IdViaje, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Mantenimiento_ObtenerPorId")]
        public async Task<IActionResult> Mantenimiento_ObtenerPorId([FromQuery] int IdMantenimiento, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Mantenimiento_ObtenerPorId(IdMantenimiento, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Desactivar")]
        public async Task<IActionResult> MantenimientoConcepto_Desactivar([FromQuery] int IdConcepto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_MantenimientoConcepto_Desactivar(IdConcepto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Guardar")]
        public async Task<IActionResult> MantenimientoConcepto_Guardar([FromQuery] int IdConcepto, [FromQuery] int IdEmpresa, [FromQuery] string Descripcion, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_MantenimientoConcepto_Guardar(IdConcepto, IdEmpresa, Descripcion, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Listar")]
        public async Task<IActionResult> MantenimientoConcepto_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_MantenimientoConcepto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_ObtenerPorId")]
        public async Task<IActionResult> MantenimientoConcepto_ObtenerPorId([FromQuery] int IdConcepto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_MantenimientoConcepto_ObtenerPorId(IdConcepto, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Eliminar")]
        public async Task<IActionResult> MantenimientoDetalle_Eliminar([FromQuery] int IdDetalle, [FromQuery] int IdMantenimiento)
        {
            var response = await _bs.Bs_MantenimientoDetalle_Eliminar(IdDetalle, IdMantenimiento);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Guardar")]
        public async Task<IActionResult> MantenimientoDetalle_Guardar([FromQuery] int IdDetalle, [FromQuery] int IdMantenimiento, [FromQuery] int IdConcepto, [FromQuery] decimal Cantidad, [FromQuery] decimal CostoUnitario)
        {
            var response = await _bs.Bs_MantenimientoDetalle_Guardar(IdDetalle, IdMantenimiento, IdConcepto, Cantidad, CostoUnitario);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Listar")]
        public async Task<IActionResult> MantenimientoDetalle_Listar([FromQuery] int IdMantenimiento)
        {
            var response = await _bs.Bs_MantenimientoDetalle_Listar(IdMantenimiento);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        // Nuevos 

        [HttpGet("listaDatos_TipoMantenimiento_Desactivar")]
        public async Task<IActionResult> TipoMantenimiento_Desactivar([FromQuery] int IdTipoMantenimiento, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoMantenimiento_Desactivar(IdTipoMantenimiento, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoMantenimiento_Guardar")]
        public async Task<IActionResult> TipoMantenimiento_Guardar([FromQuery] int IdTipoMantenimiento, [FromQuery] int IdEmpresa, [FromQuery] string Descripcion, [FromQuery] byte EsPreventivo, [FromQuery] byte EsCorrectivo, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_TipoMantenimiento_Guardar(IdTipoMantenimiento, IdEmpresa, Descripcion, EsPreventivo, EsCorrectivo, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoMantenimiento_Listar")]
        public async Task<IActionResult> TipoMantenimiento_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_TipoMantenimiento_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_TipoMantenimiento_ObtenerPorId")]
        public async Task<IActionResult> TipoMantenimiento_ObtenerPorId([FromQuery] int IdTipoMantenimiento, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_TipoMantenimiento_ObtenerPorId(IdTipoMantenimiento, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
