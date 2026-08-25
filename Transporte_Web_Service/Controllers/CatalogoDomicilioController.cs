using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoDomicilioController : ControllerBase
    {
        private readonly CatalogoDomicilioBussines _bs;

        public CatalogoDomicilioController(CatalogoDomicilioBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Catalogo_Domicilio")]
        public async Task<IActionResult> Catalogo_Domicilio_Listar([FromQuery] string? Codigo_Postal, [FromQuery] string? Asentamiento, [FromQuery] string? Estado, [FromQuery] string? Municipio)
        {
            var response = await _bs.Bs_Catalogo_Domicilio_Listar(Codigo_Postal, Asentamiento, Estado, Municipio);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
