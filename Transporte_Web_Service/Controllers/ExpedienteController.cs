using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpedienteController : ControllerBase
    {
        private readonly ExpedienteBussines _bs;

        public ExpedienteController(ExpedienteBussines bs)
        {
            _bs = bs;
        }

        [HttpPost("tipo-documento/guardar")]
        public async Task<IActionResult> TipoDocumentoViaje_Guardar([FromBody] Entity_TipoDocumentoViaje_Guardar entidad)
        {
            var response = await _bs.Bs_TipoDocumentoViaje_Guardar(entidad);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("tipo-documento/listar")]
        public async Task<IActionResult> TipoDocumentoViaje_Listar(int IdEmpresa, int? IdSucursal = null, bool SoloActivos = true, string? TipoEvento = null)
        {
            var response = await _bs.Bs_TipoDocumentoViaje_Listar(IdEmpresa, IdSucursal, SoloActivos, TipoEvento);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("documento/guardar")]
        public async Task<IActionResult> ViajeDocumento_Guardar([FromBody] Entity_ViajeDocumento_Guardar entidad)
        {
            var response = await _bs.Bs_ViajeDocumento_Guardar(entidad);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("documento/subir")]
        [RequestSizeLimit(50_000_000)]
        public async Task<IActionResult> ViajeDocumento_Subir([FromForm] Entity_ViajeDocumento_Subir entidad, IFormFile archivo)
        {
            var response = await _bs.Bs_ViajeDocumento_Subir(entidad, archivo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("documento/listar-por-viaje")]
        public async Task<IActionResult> ViajeDocumento_ListarPorViaje(int IdViaje, int IdEmpresa, string? TipoEvento = null, bool SoloActivos = true)
        {
            var response = await _bs.Bs_ViajeDocumento_ListarPorViaje(IdViaje, IdEmpresa, TipoEvento, SoloActivos);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("documento/eliminar")]
        public async Task<IActionResult> ViajeDocumento_Eliminar(int IdViajeDocumento, int IdEmpresa, int? IdUsuario = null)
        {
            var response = await _bs.Bs_ViajeDocumento_Eliminar(IdViajeDocumento, IdEmpresa, IdUsuario);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("viaje/obtener")]
        public async Task<IActionResult> ViajeExpediente_Obtener(int IdViaje, int IdEmpresa)
        {
            var response = await _bs.Bs_ViajeExpediente_Obtener(IdViaje, IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
