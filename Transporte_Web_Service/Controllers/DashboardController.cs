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
        public IActionResult Dashboard_CostosPorTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            // Ejecuta la lógica de negocio
            RespuestaApi resultado = _bs.Bs_Dashboard_CostosPorTipo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            // Manejo de códigos de estado HTTP correctos según tu estatus interno
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado); // Error de servidor, .NET lo vuelve JSON automáticamente
            }

            return Ok(resultado); // Retorna un HTTP 200 con el objeto convertido a JSON nativamente
        }


        [HttpGet("RentabilidadMensual")]
        public IActionResult Dashboard_RentabilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
        {
            RespuestaApi resultado = _bs.Bs_Dashboard_RentabilidadMensual(IdEmpresa, IdSucursal, Anio);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("ResumenOperativo")]
        public IActionResult Dashboard_ResumenOperativo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            RespuestaApi resultado = _bs.Bs_Dashboard_ResumenOperativo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("TopClientes")]

        public IActionResult Dashboard_TopClientes(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            RespuestaApi resultado = _bs.Bs_DashBoard_TopClientes(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }
            return Ok(resultado);
        }


        [HttpGet("ViajesPorEstado")]
        public IActionResult Dashboard_ViajesPorEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            RespuestaApi resultado = _bs.Bs_Dashboard_ViajesPorEstado(IdEmpresa, IdSucursal, FechaInicio, FechaFin);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
