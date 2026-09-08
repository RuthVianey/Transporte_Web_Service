using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SatCatalogosController : ControllerBase
    {
        private readonly SatCatalogosBussines _bs;

        public SatCatalogosController(SatCatalogosBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_SatCatalogoProdServ_Listar")]
        public async Task<IActionResult> SatCatalogoProdServ_Listar([FromQuery] string? TextoBusqueda, [FromQuery] bool SoloVigentes = true, [FromQuery] int Top = 100)
        {
            var response = await _bs.Bs_SatCatalogoProdServ_Listar(TextoBusqueda, SoloVigentes, Top);
            return Ok(response);
        }

        [HttpGet("listaDatos_SatCatalogoRegimenFiscal_Listar")]
        public async Task<IActionResult> SatCatalogoRegimenFiscal_Listar([FromQuery] string? TextoBusqueda, [FromQuery] byte? TipoPersona, [FromQuery] int Top = 100)
        {
            var response = await _bs.Bs_SatCatalogoRegimenFiscal_Listar(TextoBusqueda, TipoPersona, Top);
            return Ok(response);
        }

        [HttpGet("listaDatos_SatCatalogoUM_Listar")]
        public async Task<IActionResult> SatCatalogoUM_Listar([FromQuery] string? TextoBusqueda, [FromQuery] int Top = 100)
        {
            var response = await _bs.Bs_SatCatalogoUM_Listar(TextoBusqueda, Top);
            return Ok(response);
        }
    }
}
