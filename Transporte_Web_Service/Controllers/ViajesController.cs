using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViajesController : ControllerBase
    {
        private readonly ViajesBussines _bs;

        public ViajesController(ViajesBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_EstadoViaje_Guardar")]
        public async Task<IActionResult> EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {
            var response = await _bs.Bs_EstadoViaje_Guardar(IdEstadoViaje, Descripcion);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_EstadoViaje_Listar")]
        public async Task<IActionResult> EstadoViaje_Listar()
        {
            var response = await _bs.Bs_EstadoViaje_Listar();

            if(!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_EstadoViaje_ObtenerPorId")]
        public async Task<IActionResult> EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {
            var response = await _bs.Bs_EstadoViaje_ObtenerPorId(IdEstadoViaje);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpGet("listaDatos_Viaje_Listar")]
        public async Task<IActionResult> Viaje_Listar([FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] int? IdCliente, [FromQuery] int? IdOperador, [FromQuery] int? IdEstadoViaje, [FromQuery] DateTime? FechaInicio, [FromQuery] DateTime? FechaFin, [FromQuery] string? TextoBusqueda)
        {
            var response = await _bs.Bs_Viaje_Listar(IdEmpresa, IdSucursal, IdCliente, IdOperador, IdEstadoViaje, FechaInicio, FechaFin, TextoBusqueda);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Viaje_ObtenerPorId")]
        public async Task<IActionResult> Viaje_ObtenerPorId([FromQuery] int IdViaje, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Viaje_ObtenerPorId(IdViaje, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("listaDatos_Viaje_Guardar")]
        public async Task<IActionResult> Viaje_Guardar([FromQuery] int? IdViaje, [FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] int? IdOperador, [FromQuery] int IdCliente, [FromQuery] int? IdRuta, [FromQuery] int IdEstadoViaje, [FromQuery] DateTime? FechaSalida, [FromQuery] DateTime? FechaLlegadaEstimada, [FromQuery] DateTime? FechaLlegadaReal, [FromQuery] string? Origen, [FromQuery] string? Destino, [FromQuery] decimal? KmInicial, [FromQuery] decimal? KmFinal, [FromQuery] decimal Ingreso, [FromQuery] decimal? PrecioPactado, [FromQuery] string? Observaciones)
        {
            var response = await _bs.Bs_Viaje_Guardar(IdViaje, IdEmpresa, IdSucursal, IdOperador, IdCliente, IdRuta, IdEstadoViaje, FechaSalida, FechaLlegadaEstimada, FechaLlegadaReal, Origen, Destino, KmInicial, KmFinal, Ingreso, PrecioPactado, Observaciones);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("listaDatos_ViajeMovimiento_Guardar")]
        public async Task<IActionResult> ViajeMovimiento_Guardar([FromQuery] int? IdViajeMovimiento, [FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] int IdViaje, [FromQuery] string TipoMovimiento, [FromQuery] int? Secuencia, [FromQuery] DateTime? FechaMovimiento, [FromQuery] string? Lugar, [FromQuery] string? ClienteDestino, [FromQuery] int? IdProducto, [FromQuery] string? Producto, [FromQuery] decimal Cantidad, [FromQuery] string? UnidadMedida, [FromQuery] decimal? Temperatura, [FromQuery] decimal? Densidad, [FromQuery] string? Referencia, [FromQuery] string? Observaciones, [FromQuery] int? IdUsuarioRegistro)
        {
            var response = await _bs.Bs_ViajeMovimiento_Guardar(IdViajeMovimiento, IdEmpresa, IdSucursal, IdViaje, TipoMovimiento, Secuencia, FechaMovimiento, Lugar, ClienteDestino, IdProducto, Producto, Cantidad, UnidadMedida, Temperatura, Densidad, Referencia, Observaciones, IdUsuarioRegistro);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_ViajeMovimiento_ListarPorViaje")]
        public async Task<IActionResult> ViajeMovimiento_ListarPorViaje([FromQuery] int IdViaje, [FromQuery] int IdEmpresa, [FromQuery] string? TipoMovimiento, [FromQuery] bool SoloActivos = true)
        {
            var response = await _bs.Bs_ViajeMovimiento_ListarPorViaje(IdViaje, IdEmpresa, TipoMovimiento, SoloActivos);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_ViajeMovimiento_Eliminar")]
        public async Task<IActionResult> ViajeMovimiento_Eliminar([FromQuery] int IdViajeMovimiento, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_ViajeMovimiento_Eliminar(IdViajeMovimiento, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
    }
}


