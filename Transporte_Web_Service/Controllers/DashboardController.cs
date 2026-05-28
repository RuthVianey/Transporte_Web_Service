using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

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
        //public object Dashboard_CostosPorTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        //{
        //    return _bs.Bs_Dashboard_CostosPorTipo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
        //}
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
        public object Dashboard_RentabilidadMensual(int IdEmpresa, int IdSucursal, int Anio)
        {
            return _bs.Bs_Dashboard_RentabilidadMensual(IdEmpresa, IdSucursal, Anio);
        }

        [HttpGet("ResumenOperativo")]
        public object Dashboard_ResumenOperativo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            return _bs.Bs_Dashboard_ResumenOperativo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
        }

        [HttpGet("ViajesPorEstado")]
        public object Dashboard_ViajesPorEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            return _bs.Bs_Dashboard_ViajesPorEstado(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
        }
    }
}
