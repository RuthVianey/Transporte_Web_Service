using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

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
        public object Cliente_ObtenerPorId(int iIdCliente, int iIdEmpresa)
        {
            return _bs.Cliente_ObtenerPorId(iIdCliente, iIdEmpresa);
        }

        [HttpPost("listaDatos_Cliente_Listar")]
        public object Cliente_Listar(int iIdEmpresa, int iIdSucursal, string sSoloActivos, string sTextoBusqueda)
        {
            return _bs.Cliente_Listar(iIdEmpresa, iIdSucursal, sSoloActivos, sTextoBusqueda);
        }

        [HttpPost("listaDatos_Cliente_Guardar")]
        public object Cliente_Guardar(int iIdCliente, int iIdEmpresa, int iIdSucursal, string sNombre, string sRFC, string sTelefono, string sEmail, int iRegimenFiscal, byte bActivo)
        {
            return _bs.Cliente_Guardar(iIdCliente, iIdEmpresa, iIdSucursal, sNombre, sRFC, sTelefono, sEmail, iRegimenFiscal, bActivo);
        }

        [HttpPost("listaDatos_Cliente_Desactivar")]
        public object Cliente_Desactivar(int iIdCliente, int iIdEmpresa)
        {
            return _bs.Cliente_Desactivar(iIdCliente, iIdEmpresa);
        }
    }
}
