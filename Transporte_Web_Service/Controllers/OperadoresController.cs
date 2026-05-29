using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperadoresController : ControllerBase
    {
        private readonly OperadoresBussines _bs;

        public OperadoresController(OperadoresBussines bs)
        {
            _bs = bs;
        }

        [HttpPost("listaDatos_Operador_Desactivar")]
        public IActionResult Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Operador_Desactivar(iIdOperador, iIdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Operador_Guardar")]
        public IActionResult Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            RespuestaApi resultado = _bs.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Operador_Listar")]
        public IActionResult Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            RespuestaApi resultado = _bs.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Operador_ObtenerPorId")]
        public IActionResult Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            RespuestaApi resultado = _bs.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
