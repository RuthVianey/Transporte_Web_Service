using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class General : ControllerBase
    {
        private readonly GeneralesBS _bs;

        public General(GeneralesBS bs)
        {
            _bs = bs;
        }

        [HttpGet("dato_Empresa_Guardar")]
        public async Task<IActionResult> Empresa_Guardar([FromQuery] int iIdEmpresa, [FromQuery] string sNombre, [FromQuery] string sNombre_Corto, [FromQuery] string sRFC, [FromQuery] string sCalle, [FromQuery] string sColonia, [FromQuery] string sMunicipio, [FromQuery] string sEstado, [FromQuery] string sCodigo_Postal, [FromQuery] string sTelefono, [FromQuery] string sRutaLogo, [FromQuery] byte bActivo, [FromQuery] string sTipoImagen)
        {
            var response = await _bs.Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo, sTipoImagen);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("dato_Empresa_Desactivar")]
        public async Task<IActionResult> Empresa_Desactivar([FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Empresa_Desactivar(iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("Empresa_Listar")]
        public async Task<IActionResult> Empresa_Listar([FromQuery] byte bSoloActivos, [FromQuery] string sTextoBusqueda)
        {
            var response = await _bs.Empresa_Listar(bSoloActivos, sTextoBusqueda);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("dato_Empresa_ObtenerPorId")]
        public async Task<IActionResult> Empresa_ObtenerPorId([FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Empresa_ObtenerPorId(iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Programa_Listar")]
        public async Task<IActionResult> Programa_Listar()
        {
            var response = await _bs.Bs_Programa_Listar();

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //[HttpPost("dato_Actualizar_Empresa")]
        //public object Actualizar_Empresa(string sBaseDatos, int iTipo, int iIdEmpresa, string sNombre_Completo, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, string sTipoImagen)
        //{
        //    return _bs.Actualizar_Empresa(iTipo, iIdEmpresa, sNombre_Completo, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, sTipoImagen);
        //}

        //[HttpPost("listaDatos_Obtienen_Datos_Empresa")]
        //public object Obtienen_Datos_Empresa(string sBaseDatos, int iIdEmpresa)
        //{
        //    return _bs.Obtienen_Datos_Empresa(iIdEmpresa);
        //}

        //[HttpPost("listaDatos_Obtiene_Empresa_Por_Correo")]
        //public object Obtiene_Empresa_Por_Correo(string sBaseDatos, string sEmail)
        //{
        //    return _bs.Obtiene_Empresa_Por_Correo(sEmail);
        //}
    }
}
