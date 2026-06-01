using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly GastosBussines _bs;

        public GastosController(GastosBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Gasto_Eliminar")]
        public IActionResult Gasto_Eliminar(int IdGasto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Gasto_Eliminar(IdGasto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Gasto_Guardar")]
        public IActionResult Gasto_Guardar(int IdGasto, int IdEmpresa, int IdSucursal, int IdTipoGasto, int IdViaje, int IdUnidad, string Fecha, decimal Monto, string Referencia, string Descripcion, byte EsFacturable)
        {
            RespuestaApi resultado = _bs.Bs_Gasto_Guardar(IdGasto, IdEmpresa, IdSucursal, IdTipoGasto, IdViaje, IdUnidad, Fecha, Monto, Referencia, Descripcion, EsFacturable);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Gasto_ListarPorViaje")]
        public IActionResult Gasto_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Gasto_ListarPorViaje(IdViaje, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Gasto_ObtenerPorId")]
        public IActionResult Gasto_ObtenerPorId(int IdGasto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Gasto_ObtenerPorId(IdGasto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoGasto_Desactivar")]
        public IActionResult TipoGasto_Desactivar(int IdTipoGasto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_TipoGasto_Desactivar(IdTipoGasto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoGasto_Guardar")]
        public IActionResult TipoGasto_Guardar(int IdTipoGasto, int IdEmpresa, string Descripcion, byte EsCostoDirecto, byte EsMantenimiento, byte EsCombustible, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_TipoGasto_Guardar(IdTipoGasto, IdEmpresa, Descripcion, EsCostoDirecto, EsMantenimiento, EsCombustible, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoGasto_Listar")]
        public IActionResult TipoGasto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_TipoGasto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoGasto_ObtenerPorId")]
        public IActionResult TipoGasto_ObtenerPorId(int IdTipoGasto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_TipoGasto_ObtenerPorId(IdTipoGasto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
