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

        [HttpGet("listaDatos_CargaCombustible_Eliminar")]
        public async Task<IActionResult> CargaCombustible_Eliminar(int IdCarga, int IdEmpresa)
        {
            var response = await _bs.Bs_CargaCombustible_Eliminar(IdCarga, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_CargaCombustible_Guardar")]
        public async Task<IActionResult> CargaCombustible_Guardar(int IdCarga, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, string Fecha, decimal Litros, decimal PrecioLitro, decimal Km, decimal Odometro, decimal RendimientoKmPorLitro, string Referencia)
        {
            var response = await _bs.Bs_CargaCombustible_Guardar(IdCarga, IdEmpresa, IdSucursal, IdUnidad, IdViaje, Fecha, Litros, PrecioLitro, Km, Odometro, RendimientoKmPorLitro, Referencia);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_CargaCombustible_ListarPorViaje")]
        public async Task<IActionResult> CargaCombustible_ListarPorViaje(int IdEmpresa, int IdViaje)
        {
            var response = await _bs.Bs_CargaCombustible_ListarPorViaje(IdEmpresa, IdViaje);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_CargaCombustible_ObtenerPorId")]
        public async Task<IActionResult> CargaCombustible_ObtenerPorId(int IdEmpresa, int IdCarga)
        {
            var response = await _bs.Bs_CargaCombustible_ObtenerPorId(IdEmpresa, IdCarga);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
