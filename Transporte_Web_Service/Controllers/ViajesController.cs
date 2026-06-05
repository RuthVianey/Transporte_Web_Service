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

    }
}
