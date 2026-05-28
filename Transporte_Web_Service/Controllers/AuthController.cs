using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

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

        [HttpPost("listaDatos_Usuario_Valida")]
        public object Usuario_Valida(int iIdEmpresa, string sEmail, string sPasswordIngresado)
        {
            return _bs.Usuario_Valida(iIdEmpresa, sEmail, sPasswordIngresado);
        }

        [HttpPost("listaDatos_Usuarios_Empresa")]
        public object Usuarios_Empresa(int iIdEmpresa)
        {
            return _bs.Usuarios_Empresa(iIdEmpresa);
        }
    }
}
