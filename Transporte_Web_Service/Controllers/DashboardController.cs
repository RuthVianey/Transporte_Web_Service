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


        [HttpGet("ViajesPorEstado")]
        public object Dashboard_ViajesPorEstado(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            return _bs.Dashboard_ViajesPorEstado(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
        }

        [HttpGet("CostosPorTipo")]
        public object Dashboard_CostosPorTipo(int IdEmpresa, int IdSucursal, string FechaInicio, string FechaFin)
        {
            return _bs.Dashboard_CostosPorTipo(IdEmpresa, IdSucursal, FechaInicio, FechaFin);
        }

    }
}
