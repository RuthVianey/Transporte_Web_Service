using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

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

        [HttpPost("listaDatos_Operador_ObtenerPorId")]
        public object Operador_ObtenerPorId(int iIdEmpresa, int iIdOperador)
        {
            return _bs.Operador_ObtenerPorId(iIdEmpresa, iIdOperador);
        }

        [HttpPost("listaDatos_Operador_Listar")]
        public object Operador_Listar(int iIdEmpresa, int iIdSucursal, byte bSoloActivos, string sTextoBusqueda)
        {
            return _bs.Operador_Listar(iIdEmpresa, iIdSucursal, bSoloActivos, sTextoBusqueda);
        }

        [HttpPost("listaDatos_Operador_Guardar")]
        public object Operador_Guardar(int iIdOperador, int iIdEmpresa, int iIdSucursal, string sNombre, string sLicencia, string sTipoLicencia, string sFechaVencimientoLicencia, string sCURP, string sTelefono, byte bActivo)
        {
            return _bs.Operador_Guardar(iIdOperador, iIdEmpresa, iIdSucursal, sNombre, sLicencia, sTipoLicencia, sFechaVencimientoLicencia, sCURP, sTelefono, bActivo);
        }

        [HttpPost("listaDatos_Operador_Desactivar")]
        public object Operador_Desactivar(int iIdOperador, int iIdEmpresa)
        {
            return _bs.Operador_Desactivar(iIdOperador, iIdEmpresa);
        }
    }
}
