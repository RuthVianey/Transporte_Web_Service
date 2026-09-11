using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpedienteController : ControllerBase
    {
        private readonly ExpedienteBussines _bs;
        private readonly AuditoriaBussines _auditoria;

        public ExpedienteController(ExpedienteBussines bs, AuditoriaBussines auditoria)
        {
            _bs = bs;
            _auditoria = auditoria;
        }

        [HttpPost("tipo-documento/guardar")]
        public async Task<IActionResult> TipoDocumentoViaje_Guardar([FromBody] Entity_TipoDocumentoViaje_Guardar entidad)
        {
            var response = await _bs.Bs_TipoDocumentoViaje_Guardar(entidad);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            await RegistrarAuditoria(entidad.IdEmpresa, entidad.IdTipoDocumentoViaje > 0 ? "MODIFICAR" : "CREAR", "Tipo de documento", response.Data?.FirstOrDefault()?.ID, entidad.Descripcion);
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

            await RegistrarAuditoria(entidad.IdEmpresa, entidad.IdViajeDocumento.HasValue && entidad.IdViajeDocumento.Value > 0 ? "MODIFICAR" : "CREAR", "Documento del viaje", response.Data?.FirstOrDefault()?.ID, $"Viaje {entidad.IdViaje}: {entidad.NombreOriginal}");
            return Ok(response);
        }

        [HttpPost("evento/guardar")]
        public async Task<IActionResult> EventoViaje_Guardar([FromBody] Entity_EventoViaje_Guardar entidad)
        {
            var response = await _bs.Bs_EventoViaje_Guardar(entidad);
            if (response.Ok) await RegistrarAuditoria(entidad.IdEmpresa, entidad.IdEvento.GetValueOrDefault() > 0 ? "MODIFICAR" : "CREAR", "Evento de viaje", response.Data?.FirstOrDefault()?.ID, $"Viaje {entidad.IdViaje}: {entidad.TipoEvento}");
            return response.Ok ? Ok(response) : BadRequest(response);
        }

        [HttpPost("documento/revisar")]
        public async Task<IActionResult> ViajeDocumento_Revisar([FromBody] Entity_ViajeDocumento_Revisar entidad)
        {
            var response = await _bs.Bs_ViajeDocumento_Revisar(entidad);
            if (response.Ok) await RegistrarAuditoria(entidad.IdEmpresa, string.Equals(entidad.EstadoRevision, "RECHAZADO", StringComparison.OrdinalIgnoreCase) ? "RECHAZAR" : "APROBAR", "Revisión de evidencia", entidad.IdViajeDocumento, entidad.ComentarioRevision);
            return response.Ok ? Ok(response) : BadRequest(response);
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

            await RegistrarAuditoria(entidad.IdEmpresa, "CREAR", "Documento del viaje", response.Data?.FirstOrDefault()?.ID, $"Viaje {entidad.IdViaje}: {archivo.FileName}");
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

        [HttpGet("documento/abrir")]
        public async Task<IActionResult> ViajeDocumento_Abrir(int IdViajeDocumento, int IdViaje, int IdEmpresa)
        {
            var response = await _bs.Bs_ViajeDocumento_ObtenerArchivo(IdViajeDocumento, IdViaje, IdEmpresa);
            if (!response.Ok || response.Data == null)
            {
                return NotFound(response);
            }

            await RegistrarAuditoria(IdEmpresa, "DESCARGAR", "Documento del viaje", IdViajeDocumento, $"Viaje {IdViaje}: {response.Data.NombreDescarga}");
            return PhysicalFile(response.Data.RutaFisica, response.Data.ContentType, response.Data.NombreDescarga, enableRangeProcessing: true);
        }

        [HttpDelete("documento/eliminar")]
        public async Task<IActionResult> ViajeDocumento_Eliminar(int IdViajeDocumento, int IdEmpresa, int? IdUsuario = null)
        {
            var response = await _bs.Bs_ViajeDocumento_Eliminar(IdViajeDocumento, IdEmpresa, IdUsuario);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            await RegistrarAuditoria(IdEmpresa, "ELIMINAR", "Documento del viaje", IdViajeDocumento, null);
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

        private Task RegistrarAuditoria(int idEmpresa, string accion, string recurso, int? idRegistro, string? detalle)
        {
            var idUsuario = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var usuario) ? usuario : (int?)null;
            return _auditoria.Registrar(idEmpresa, idUsuario, "EXPEDIENTES", accion, recurso, idRegistro?.ToString(), detalle);
        }
    }
}
