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

        [HttpPost("dato_Empresa_Guardar")]
        public IActionResult Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo, string sTipoImagen)
        {
            RespuestaApi resultado = _bs.Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo, sTipoImagen);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("dato_Empresa_Desactivar")]
        public IActionResult Empresa_Desactivar(int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Empresa_Desactivar(iIdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("Empresa_Listar")]
        public IActionResult Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            RespuestaApi resultado = _bs.Empresa_Listar(bSoloActivos, sTextoBusqueda);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("dato_Empresa_ObtenerPorId")]
        public IActionResult Empresa_ObtenerPorId(int iIdEmpresa)
        {
            RespuestaApi resultado = _bs.Empresa_ObtenerPorId(iIdEmpresa);

            if (resultado.Estatus == -1)
            {
                return StatusCode(500, resultado);
            }

            return Ok(resultado);
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
