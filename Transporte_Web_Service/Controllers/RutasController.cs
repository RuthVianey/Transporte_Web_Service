using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly RutasBussines _bs;

        public RutasController(RutasBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Ruta_Desactivar")]
        public IActionResult Ruta_Desactivar(int IdRuta, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Ruta_Desactivar(IdRuta, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Ruta_Guardar")]
        public IActionResult Ruta_Guardar(int IdRuta, int IdEmpresa, int IdSucursal, string Nombre, string Origen, string Destino, decimal DistanciaKm, int TiempoEstimadoMin, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_Ruta_Guardar(IdRuta, IdEmpresa, IdSucursal, Nombre, Origen, Destino, DistanciaKm, TiempoEstimadoMin, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Ruta_Listar")]
        public IActionResult Ruta_Listar(int IdEmpresa, int IdSucursal, byte SoloActivos, string TextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_Ruta_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Ruta_ObtenerPorId")]
        public IActionResult Ruta_ObtenerPorId(int IdRuta, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Ruta_ObtenerPorId(IdRuta, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RutaDetalle_Eliminar")]
        public IActionResult RutaDetalle_Eliminar(int IdRutaDetalle, int IdRuta)
        {
            RespuestaApi resultado = _bs.Bs_RutaDetalle_Eliminar(IdRutaDetalle, IdRuta);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RutaDetalle_Guardar")]
        public IActionResult RutaDetalle_Guardar(int IdRutaDetalle, int IdRuta, int Orden, string Punto, decimal Latitud, decimal Longitud, string Tipo)
        {
            RespuestaApi resultado = _bs.Bs_RutaDetalle_Guardar(IdRutaDetalle, IdRuta, Orden, Punto, Latitud, Longitud, Tipo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RutaDetalle_Listar")]
        public IActionResult RutaDetalle_Listar(int IdRuta)
        {
            RespuestaApi resultado = _bs.Bs_RutaDetalle_Listar(IdRuta);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_RutaDetalle_ObtenerPorId")]
        public IActionResult RutaDetalle_ObtenerPorId(int IdRutaDetalle, int IdRuta)
        {
            RespuestaApi resultado = _bs.Bs_RutaDetalle_ObtenerPorId(IdRutaDetalle, IdRuta);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

    }
}
