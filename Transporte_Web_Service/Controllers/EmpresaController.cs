using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

using Microsoft.AspNetCore.Mvc;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaBussines _bs;

        public EmpresaController(EmpresaBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Empresa_Desactivar")]
        public IActionResult Empresa_Desactivar(int IdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Empresa_Desactivar(IdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Empresa_Guardar")]
        public IActionResult Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo)
        {
            RespuestaApi resultado = _bs.Bs_Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Empresa_Listar")]
        public IActionResult Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            RespuestaApi resultado = _bs.Bs_Empresa_Listar(bSoloActivos, sTextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("listaDatos_Empresa_ObtenerPorId")]
        public IActionResult Empresa_ObtenerPorId(int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Bs_Empresa_ObtenerPorId(iIdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
