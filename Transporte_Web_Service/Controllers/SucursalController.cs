using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Transporte_Web_Service.Entity.Respuesta;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly SeguridadBussines _bs;

        public SucursalController(SeguridadBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Sucursal_Desactivar")]
        public IActionResult Sucursal_Desactivar(int IdSucursal, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Sucursal_Desactivar(IdSucursal, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Sucursal_Guardar")]
        public IActionResult Sucursal_Guardar(int IdSucursal, int IdEmpresa, string Nombre, string NombreCorto, string Codigo, string Calle, string Colonia, string Municipio, string Estado, string CodigoPostal, string Telefono, byte Activo)
        {
            RespuestaApi resultado = _bs.Bs_Sucursal_Guardar(IdSucursal, IdEmpresa, Nombre, NombreCorto, Codigo, Calle, Colonia, Municipio, Estado, CodigoPostal, Telefono, Activo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Sucursal_Listar")]
        public IActionResult Sucursal_Listar(int IdEmpresa, byte SoloActivos, string TextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_Sucursal_Listar(IdEmpresa, SoloActivos, TextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Sucursal_ObtenerPorId")]
        public IActionResult Sucursal_ObtenerPorId(int IdSucursal, int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Sucursal_ObtenerPorId(IdSucursal, IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
