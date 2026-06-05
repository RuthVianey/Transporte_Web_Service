using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthBussines _bs;

        public AuthController(AuthBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Usuario_Valida")]
        public async Task<IActionResult> Usuario_Valida([FromQuery] int iIdEmpresa, [FromQuery] string sEmail, [FromQuery] string sPasswordIngresado)
        {
            var response = await _bs.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Usuarios_Empresa")]
        public async Task<IActionResult> Usuarios_Empresa([FromQuery] string iIdEmpresa)
        {
            var response = await _bs.Usuarios_Empresa(iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
