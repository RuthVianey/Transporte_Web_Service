using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

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
        public object Empresa_Guardar(int iIdEmpresa, string sNombre, string sNombre_Corto, string sRFC, string sCalle, string sColonia, string sMunicipio, string sEstado, string sCodigo_Postal, string sTelefono, string sRutaLogo, byte bActivo, string sTipoImagen)
        {
            return _bs.Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo, sTipoImagen);
        }

        [HttpPost("dato_Empresa_Desactivar")]
        public object Empresa_Desactivar(int iIdEmpresa)
        {
            return _bs.Empresa_Desactivar(iIdEmpresa);
        }

        [HttpPost("Empresa_Listar")]
        public object Empresa_Listar(byte bSoloActivos, string sTextoBusqueda)
        {
            return _bs.Empresa_Listar(bSoloActivos, sTextoBusqueda);
        }

        [HttpPost("dato_Empresa_ObtenerPorId")]
        public object Empresa_ObtenerPorId(int iIdEmpresa)
        {
            return _bs.Empresa_ObtenerPorId(iIdEmpresa);
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
