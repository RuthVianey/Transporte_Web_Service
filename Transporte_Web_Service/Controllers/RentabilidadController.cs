using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RentabilidadController : Controller
    {
        private readonly RentabilidadBussines _bs;

        public RentabilidadController(RentabilidadBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("ListarViajes")]
        public async Task<IActionResult> Rentabilidad_ListarViajes([FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] DateTime? FechaInicio,
                                                                [FromQuery] DateTime? FechaFin, [FromQuery] int? IdCliente, [FromQuery] int? IdUnidad, [FromQuery] int? IdRuta)
        {
            var response = await _bs.Bs_Rentabilidad_ListarViajes(IdEmpresa, IdSucursal, FechaInicio, FechaFin, IdCliente, IdUnidad, IdRuta);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
