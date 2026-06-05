using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesBussines _bs;

        public ClientesController(ClientesBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Cliente_Desactivar")]
        public async Task<IActionResult> Cliente_Desactivar([FromQuery] int iIdCliente, [FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Bs_Cliente_Desactivar(iIdCliente, iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Cliente_Guardar")]
        public async Task<IActionResult> Cliente_Guardar([FromQuery] int iIdCliente, [FromQuery] int iIdEmpresa, [FromQuery] int iIdSucursal, [FromQuery] string sNombre, [FromQuery] string sRFC, [FromQuery] string sTelefono, [FromQuery] string sEmail, [FromQuery] int iRegimenFiscal, [FromQuery] byte bActivo)
        {
            var response = await _bs.Bs_Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Cliente_Listar")]
        public async Task<IActionResult> Cliente_Listar([FromQuery] int iIdEmpresa, [FromQuery] int iIdSucursal, [FromQuery] string sSoloActivos, [FromQuery] string sTextoBusqueda)
        {
            var response = await _bs.Bs_Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Cliente_ObtenerPorId")]
        public async Task<IActionResult> Cliente_ObtenerPorId([FromQuery] int iIdCliente, [FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Bs_Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
