using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoBussines _bs;

        public MantenimientoController(MantenimientoBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Mantenimiento_Eliminar")]
        public IActionResult Mantenimiento_Eliminar(int IdMantenimiento, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Mantenimiento_Eliminar(IdMantenimiento, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Mantenimiento_Guardar")]
        public IActionResult Mantenimiento_Guardar(int IdMantenimiento, int IdEmpresa, int IdSucursal, int IdUnidad, int IdViaje, int IdTipoMantenimiento, string Fecha, decimal KmUnidad, string Descripcion, decimal Costo, byte EsAsignableAViaje)
        {
            RespuestaApi resultado = _bs.Bs_Mantenimiento_Guardar(IdMantenimiento, IdEmpresa, IdSucursal, IdUnidad, IdViaje, IdTipoMantenimiento, Fecha, KmUnidad, Descripcion, Costo, EsAsignableAViaje);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Mantenimiento_ListarPorViaje")]
        public IActionResult Mantenimiento_ListarPorViaje(int IdViaje, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Mantenimiento_ListarPorViaje(IdViaje, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Mantenimiento_ObtenerPorId")]
        public IActionResult Mantenimiento_ObtenerPorId(int IdMantenimiento, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Mantenimiento_ObtenerPorId(IdMantenimiento, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Desactivar")]
        public IActionResult MantenimientoConcepto_Desactivar(int IdConcepto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoConcepto_Desactivar(IdConcepto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Guardar")]
        public IActionResult MantenimientoConcepto_Guardar(int IdConcepto, int IdEmpresa, string Descripcion, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoConcepto_Guardar(IdConcepto, IdEmpresa, Descripcion, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_Listar")]
        public IActionResult MantenimientoConcepto_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoConcepto_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoConcepto_ObtenerPorId")]
        public IActionResult MantenimientoConcepto_ObtenerPorId(int IdConcepto, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoConcepto_ObtenerPorId(IdConcepto, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Eliminar")]
        public IActionResult MantenimientoDetalle_Eliminar(int IdDetalle, int IdMantenimiento)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoDetalle_Eliminar(IdDetalle, IdMantenimiento);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Guardar")]
        public IActionResult MantenimientoDetalle_Guardar(int IdDetalle, int IdMantenimiento, int IdConcepto, decimal Cantidad, decimal CostoUnitario)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoDetalle_Guardar(IdDetalle, IdMantenimiento, IdConcepto, Cantidad, CostoUnitario);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_MantenimientoDetalle_Listar")]
        public IActionResult MantenimientoDetalle_Listar(int IdMantenimiento)
        {
            RespuestaApi resultado = _bs.Bs_MantenimientoDetalle_Listar(IdMantenimiento);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
