using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Usuarios : ControllerBase
    {
        private readonly UsuariosBS _Ubs;

        public Usuarios(UsuariosBS ubs)
        {
            _Ubs = ubs;
        }

        /*COMIENZA USUARIO*/

        [HttpPost("listaDatos_Usuario_Guardar")]
        public IActionResult Usuario_Guardar(int iIdUsuario, int iIdEmpresa, string sNombre, string sEmail, string sContrasenia, int iIdSucursal)
        {
            RespuestaApi resultado = _Ubs.Usuario_Guardar(iIdUsuario, iIdEmpresa, sNombre, sEmail, sContrasenia, iIdSucursal);
            
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
