using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Usuarios : ControllerBase
    {
        private readonly UsuariosBS _bs;

        public Usuarios(UsuariosBS bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Usuario_Guardar")]
        public async Task<IActionResult> Usuario_Guardar([FromQuery] int IdUsuario, [FromQuery] int IdEmpresa, [FromQuery] string Nombre, [FromQuery] string Email, [FromQuery] string Contrasenia, [FromQuery] int? IdSucursal)
        {
            var response = await _bs.Usuario_Guardar(IdUsuario, IdEmpresa, Nombre, Email, Contrasenia, IdSucursal);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Usuario_Desactivar")]
        public async Task<IActionResult> Usuario_Desactivar([FromQuery] int IdUsuario, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Usuario_Desactivar(IdUsuario, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Usuario_Listar")]
        public async Task<IActionResult> Usuario_Listar([FromQuery] int IdEmpresa, [FromQuery] byte SoloActivos, [FromQuery] string? TextoBusqueda)
        {
            var response = await _bs.Usuario_Listar(IdEmpresa, SoloActivos, TextoBusqueda);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Usuario_ObtenerPorId")]
        public async Task<IActionResult> Usuario_ObtenerPorId([FromQuery] int IdUsuario, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Usuario_ObtenerPorId(IdUsuario, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
    }
}