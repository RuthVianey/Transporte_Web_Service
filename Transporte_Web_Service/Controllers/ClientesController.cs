using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesBussines _bs;

        public ClientesController(ClientesBussines bs)
        {
            _bs = bs;
        }

        [HttpPost("listaDatos_Cliente_ObtenerPorId")]
        public IActionResult Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);
            
            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Cliente_Listar")]
        public IActionResult Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            RespuestaApi resultado = _bs.Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Cliente_Guardar")]
        public IActionResult Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            RespuestaApi resultado = _bs.Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("listaDatos_Cliente_Desactivar")]
        public IActionResult Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Cliente_Desactivar(iIdCliente, iIdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
