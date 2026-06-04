using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperadoresController : ControllerBase
    {
        private readonly OperadoresBussines _bs;

        public OperadoresController(OperadoresBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Operador_Desactivar")]
        public async Task<IActionResult> Operador_Desactivar([FromQuery] int iIdOperador, [FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Operador_Desactivar(iIdOperador, iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Operador_Guardar")]
        public async Task<IActionResult> Operador_Guardar([FromQuery] int iIdOperador, [FromQuery] int iIdEmpresa, [FromQuery] int iIdSucursal, [FromQuery] string sNombre, [FromQuery] string sLicencia, [FromQuery] string sTipoLicencia, [FromQuery] string sFechaVencimientoLicencia, [FromQuery] string sCURP, [FromQuery] string sTelefono, [FromQuery] byte bActivo)
        {
            var response = await _bs.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Operador_Listar")]
        public async Task<IActionResult> Operador_Listar([FromQuery] int iIdEmpresa, [FromQuery] int iIdSucursal, [FromQuery] byte bSoloActivos, [FromQuery] string sTextoBusqueda)
        {
            var response = await _bs.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Operador_ObtenerPorId")]
        public async Task<IActionResult> Operador_ObtenerPorId([FromQuery] int iIdEmpresa, [FromQuery] int iIdOperador)
        {
            var response = await _bs.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
