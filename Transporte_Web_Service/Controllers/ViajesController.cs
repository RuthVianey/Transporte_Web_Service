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
        public IActionResult EstadoViaje_Guardar(int IdEstadoViaje, string Descripcion)
        {
            RespuestaApi resultado = _bs.Bs_EstadoViaje_Guardar(IdEstadoViaje, Descripcion);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_EstadoViaje_Listar")]
        public IActionResult EstadoViaje_Listar()
        {
            RespuestaApi resultado = _bs.Bs_EstadoViaje_Listar();

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_EstadoViaje_ObtenerPorId")]
        public IActionResult EstadoViaje_ObtenerPorId(int IdEstadoViaje)
        {
            RespuestaApi resultado = _bs.Bs_EstadoViaje_ObtenerPorId(IdEstadoViaje);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
