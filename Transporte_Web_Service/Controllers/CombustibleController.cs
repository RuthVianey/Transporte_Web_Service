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
        public IActionResult CargaCombustible_Eliminar(int IdCarga, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_CargaCombustible_Eliminar(IdCarga, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_CargaCombustible_Guardar")]
        public IActionResult CargaCombustible_Guardar(int IdCarga, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, string Fecha, decimal Litros, decimal PrecioLitro, decimal Km, decimal Odometro, decimal RendimientoKmPorLitro, string Referencia)
        {
            RespuestaApi resultado = _bs.Bs_CargaCombustible_Guardar(IdCarga, IdEmpresa, IdSucursal, IdUnidad, IdViaje, Fecha, Litros, PrecioLitro, Km, Odometro, RendimientoKmPorLitro, Referencia);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_CargaCombustible_ListarPorViaje")]
        public IActionResult CargaCombustible_ListarPorViaje(int IdEmpresa, int IdViaje)
        {
            RespuestaApi resultado = _bs.Bs_CargaCombustible_ListarPorViaje(IdEmpresa, IdViaje);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_CargaCombustible_ObtenerPorId")]
        public IActionResult CargaCombustible_ObtenerPorId(int IdEmpresa, int IdCarga)
        {
            RespuestaApi resultado = _bs.Bs_CargaCombustible_ObtenerPorId(IdEmpresa, IdCarga);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
