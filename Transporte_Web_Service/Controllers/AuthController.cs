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
        public IActionResult Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            RespuestaApi resultado = _bs.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);
            
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Usuarios_Empresa")]
        public IActionResult Usuarios_Empresa(int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Usuarios_Empresa(iIdEmpresa);
            
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
