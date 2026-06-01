using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly UnidadesBussines _bs;

        public UnidadesController(UnidadesBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_TipoUnidad_Desactivar")]
        public IActionResult TipoUnidad_Desactivar(int IdTipoUnidad, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_TipoUnidad_Desactivar(IdTipoUnidad, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoUnidad_Guardar")]
        public IActionResult TipoUnidad_Guardar(int IdTipoUnidad, int IdEmpresa, string Descripcion, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_TipoUnidad_Guardar(IdTipoUnidad, IdEmpresa, Descripcion, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoUnidad_Listar")]
        public IActionResult TipoUnidad_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_TipoUnidad_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_TipoUnidad_ObtenerPorId")]
        public IActionResult TipoUnidad_ObtenerPorId(int IdTipoUnidad, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_TipoUnidad_ObtenerPorId(IdTipoUnidad, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
