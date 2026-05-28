using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CombustibleController : ControllerBase
    {
        private readonly CombustibleBussines _bs;

        public CombustibleController(CombustibleBussines bs)
        {
            _bs = bs;
        }

        [HttpPost("listaDatos_Usuario_Valida")]
        public IActionResult Dal_CargaCombustible(int IdCarga, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Dal_CargaCombustible(IdCarga, IdEmpresa); ;

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
