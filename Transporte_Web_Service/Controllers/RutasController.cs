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
    public class RutasController : ControllerBase
    {
        private readonly RutasBussines _bs;

        public RutasController(RutasBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Ruta_Desactivar")]
        public async Task<IActionResult> Ruta_Desactivar([FromQuery] int IdRuta, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Ruta_Desactivar(IdRuta, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Ruta_Guardar")]
        public async Task<IActionResult> Ruta_Guardar([FromQuery] int IdRuta, [FromQuery] int IdEmpresa, [FromQuery] int IdSucursal, [FromQuery] string Nombre, [FromQuery] string Origen, [FromQuery] string Destino, [FromQuery] decimal DistanciaKm, [FromQuery] int TiempoEstimadoMin, [FromQuery] byte Activo)
        {
            var response = await _bs.Bs_Ruta_Guardar(IdRuta, IdEmpresa, IdSucursal, Nombre, Origen, Destino, DistanciaKm, TiempoEstimadoMin, Activo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Ruta_Listar")]
        public async Task<IActionResult> Ruta_Listar([FromQuery] int IdEmpresa, [FromQuery] int IdSucursal, [FromQuery] byte SoloActivos, [FromQuery] string TextoBusqueda)
        {
            var response = await _bs.Bs_Ruta_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Ruta_ObtenerPorId")]
        public async Task<IActionResult> Ruta_ObtenerPorId([FromQuery] int IdRuta, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Ruta_ObtenerPorId(IdRuta, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RutaDetalle_Eliminar")]
        public async Task<IActionResult> RutaDetalle_Eliminar([FromQuery] int IdRutaDetalle, [FromQuery] int IdRuta)
        {
            var response = await _bs.Bs_RutaDetalle_Eliminar(IdRutaDetalle, IdRuta);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RutaDetalle_Guardar")]
        public async Task<IActionResult> RutaDetalle_Guardar([FromQuery] int IdRutaDetalle, [FromQuery] int IdRuta, [FromQuery] int Orden, [FromQuery] string Punto, [FromQuery] decimal Latitud, [FromQuery] decimal Longitud, [FromQuery] string Tipo)
        {
            var response = await _bs.Bs_RutaDetalle_Guardar(IdRutaDetalle, IdRuta, Orden, Punto, Latitud, Longitud, Tipo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RutaDetalle_Listar")]
        public async Task<IActionResult> RutaDetalle_Listar([FromQuery] int IdRuta)
        {
            var response = await _bs.Bs_RutaDetalle_Listar(IdRuta);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_RutaDetalle_ObtenerPorId")]
        public async Task<IActionResult> RutaDetalle_ObtenerPorId([FromQuery] int IdRutaDetalle, [FromQuery] int IdRuta)
        {
            var response = await _bs.Bs_RutaDetalle_ObtenerPorId(IdRutaDetalle, IdRuta);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
