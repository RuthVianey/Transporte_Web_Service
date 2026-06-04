using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardBussines _bs;

        public DashboardController(DashboardBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("CostosPorTipo")]
        public async Task<IActionResult> Dashboard_CostosPorTipo([FromQuery] int idEmpresa, [FromQuery] int? idSucursal, 
                                                                [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin)
        {
            var response = await _bs.Bs_Dashboard_CostosPorTipo( idEmpresa, idSucursal, fechaInicio, fechaFin );

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpGet("ResumenOperativo")]
        public async Task<IActionResult> Dashboard_ResumenOperativo([FromQuery] int idEmpresa, [FromQuery] int? idSucursal,
                                                                [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin)
        {
            var response = await _bs.Bs_Dashboard_ResumenOperativo(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (!response.Ok)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpGet("RentabilidadMensual")]
        public async Task<IActionResult>Dashboard_RentabilidadMensual([FromQuery] int idEmpresa, [FromQuery] int? idSucursal,
                                                                [FromQuery] int anio)
        {
            var response = await _bs.Bs_Dashboard_RentabilidadMensual(idEmpresa, idSucursal, anio);

            if (!response.Ok)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }
       

        [HttpGet("TopClientes")]

        public async Task<IActionResult> Dashboard_TopClientes([FromQuery] int idEmpresa, [FromQuery] int? idSucursal,
                                                                [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin)
        {
            var response = await _bs.Bs_DashBoard_TopClientes(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (!response.Ok)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }


        [HttpGet("TopUnidades")]
        public async Task<IActionResult> Dashboard_TopUnidades([FromQuery] int idEmpresa, [FromQuery] int? idSucursal,
                                                                [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin)  
        {
            var response = await _bs.Dal_dashDashboardTopUnidades(idEmpresa, idSucursal, fechaInicio, fechaFin);
            if (!response.Ok)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet("ViajesPorEstado")]
        public async Task<IActionResult> Dashboard_ViajesPorEstado([FromQuery] int idEmpresa, [FromQuery] int? idSucursal,
                                                                  [FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin)
        {
            var response = await _bs.Bs_Dashboard_ViajesPorEstado(idEmpresa, idSucursal, fechaInicio, fechaFin);

            if (!response.Ok)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
