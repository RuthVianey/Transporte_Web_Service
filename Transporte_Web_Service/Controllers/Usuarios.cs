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
        {
        }

    }
}
