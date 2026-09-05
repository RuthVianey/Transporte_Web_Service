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

        [HttpPost("logo/subir")]
        [RequestSizeLimit(5_242_880)]
        public async Task<IActionResult> SubirLogo(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest(ApiResponse<string>.Fail("Selecciona una imagen."));
            }

            var extensionesPermitidas = new[] { ".png", ".jpg", ".jpeg", ".webp" };
            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            if (!extensionesPermitidas.Contains(extension))
            {
                return BadRequest(ApiResponse<string>.Fail("El logo debe ser PNG, JPG, JPEG o WEBP."));
            }

            var carpetaLogos = Path.Combine(Directory.GetCurrentDirectory(), "ArchivosEmpresa");
            Directory.CreateDirectory(carpetaLogos);

            var nombreArchivo = $"{Guid.NewGuid():N}{extension}";
            var rutaFisica = Path.Combine(carpetaLogos, nombreArchivo);
            await using var stream = System.IO.File.Create(rutaFisica);
            await archivo.CopyToAsync(stream);

            return Ok(ApiResponse<string>.Success($"/archivos/empresas/{nombreArchivo}"));
        }

        [HttpGet("listaDatos_Empresa_Desactivar")]
        public async Task<IActionResult> Empresa_Desactivar([FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Empresa_Desactivar(IdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Empresa_Guardar")]
        public async Task<IActionResult> Empresa_Guardar([FromQuery] int iIdEmpresa, [FromQuery] string sNombre, [FromQuery] string sNombre_Corto, [FromQuery] string sRFC, [FromQuery] string sCalle, [FromQuery] string sColonia, [FromQuery] string sMunicipio, [FromQuery] string sEstado, [FromQuery] string sCodigo_Postal, [FromQuery] string sTelefono, [FromQuery] string sRutaLogo, [FromQuery] byte bActivo)
        {
            var response = await _bs.Bs_Empresa_Guardar(iIdEmpresa, sNombre, sNombre_Corto, sRFC, sCalle, sColonia, sMunicipio, sEstado, sCodigo_Postal, sTelefono, sRutaLogo, bActivo);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Empresa_Listar")]
        public async Task<IActionResult> Empresa_Listar([FromQuery] byte bSoloActivos, [FromQuery] string? sTextoBusqueda = "")
        {
            var response = await _bs.Bs_Empresa_Listar(bSoloActivos, sTextoBusqueda ?? "");

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("listaDatos_Empresa_ObtenerPorId")]
        public async Task<IActionResult> Empresa_ObtenerPorId([FromQuery] int iIdEmpresa)
        {
            var response = await _bs.Bs_Empresa_ObtenerPorId(iIdEmpresa);

            if (!response.Ok)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
