using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Security;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthBussines _bs;
        private readonly AccessService _accessService;
        private readonly TokenService _tokenService;

        public AuthController(AuthBussines bs, AccessService accessService, TokenService tokenService)
        {
            _bs = bs;
            _accessService = accessService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _bs.Usuario_Valida(request.IdEmpresa, request.Email, request.Password);
            var idUsuario = response.Data ?? 0;
            if (!response.Ok || idUsuario <= 0)
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos." });

            if (request.IdSucursal.HasValue && !await _bs.SucursalPerteneceEmpresa(request.IdEmpresa, request.IdSucursal.Value))
                return BadRequest(new { mensaje = "La sucursal no pertenece a la empresa activa." });

            var access = await _accessService.GetForUser(request.IdEmpresa, idUsuario);
            if (access.Roles.Count == 0)
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = "El usuario no tiene un rol asignado." });

            return Ok(_tokenService.Create(idUsuario, request.IdEmpresa, request.IdSucursal, request.Email.Trim(), access.Roles, access.Permissions));
        }

        [HttpGet("sucursales")]
        public async Task<IActionResult> Sucursales([FromQuery] int IdEmpresa)
        {
            var response = await _bs.SucursalesEmpresa(IdEmpresa);
            return response.Ok ? Ok(response) : BadRequest(response);
        }

        [Authorize]
        [HttpPost("seleccionar-sucursal")]
        public async Task<IActionResult> SeleccionarSucursal([FromBody] SelectSucursalRequest request)
        {
            var idUsuario = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var user) ? user : 0;
            var idEmpresa = int.TryParse(User.FindFirstValue("empresa"), out var company) ? company : 0;
            if (idUsuario <= 0 || idEmpresa <= 0) return Unauthorized(new { mensaje = "La sesión no es válida." });
            if (request.IdSucursal.HasValue && !await _bs.SucursalPerteneceEmpresa(idEmpresa, request.IdSucursal.Value))
                return BadRequest(new { mensaje = "La sucursal no pertenece a la empresa activa." });

            var access = await _accessService.GetForUser(idEmpresa, idUsuario);
            return Ok(_tokenService.Create(idUsuario, idEmpresa, request.IdSucursal, User.FindFirstValue(ClaimTypes.Email) ?? string.Empty, access.Roles, access.Permissions));
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
        public async Task<IActionResult> Usuarios_Empresa([FromQuery] string sEmail)
        {
            var response = await _bs.Usuarios_Empresa(sEmail);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
