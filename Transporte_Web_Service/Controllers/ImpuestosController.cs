using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImpuestosController : ControllerBase
    {
        private readonly ImpuestosBussines _bs;
        public ImpuestosController(ImpuestosBussines bs) => _bs = bs;

        [HttpGet("listaDatos_Impuesto_Listar")]
        public async Task<IActionResult> Impuesto_Listar([FromQuery] int IdEmpresa, [FromQuery] bool SoloActivos = true)
        {
            var response = await _bs.Bs_Impuesto_Listar(IdEmpresa, SoloActivos);
            return response.Ok ? Ok(response) : BadRequest(response);
        }

        [HttpGet("listaDatos_Impuesto_Guardar")]
        public async Task<IActionResult> Impuesto_Guardar([FromQuery] int? IdImpuesto, [FromQuery] int IdEmpresa, [FromQuery] string Descripcion, [FromQuery] decimal? Porcentaje, [FromQuery] string Operacion, [FromQuery] string? ClaveSatImpuesto, [FromQuery] string Ambito = "F", [FromQuery] bool AfectaCosto = false, [FromQuery] bool Activo = true)
        {
            var response = await _bs.Bs_Impuesto_Guardar(IdImpuesto, IdEmpresa, Descripcion, Porcentaje, Operacion, ClaveSatImpuesto, Ambito, AfectaCosto, Activo);
            return response.Ok ? Ok(response) : BadRequest(response);
        }

        [HttpGet("listaDatos_ProductoImpuesto_Listar")]
        public async Task<IActionResult> ProductoImpuesto_Listar([FromQuery] int IdEmpresa, [FromQuery] int IdProducto, [FromQuery] bool SoloActivos = true)
        {
            var response = await _bs.Bs_ProductoImpuesto_Listar(IdEmpresa, IdProducto, SoloActivos);
            return response.Ok ? Ok(response) : BadRequest(response);
        }

        [HttpGet("listaDatos_ProductoImpuesto_Guardar")]
        public async Task<IActionResult> ProductoImpuesto_Guardar([FromQuery] int IdEmpresa, [FromQuery] int IdProducto, [FromQuery] int IdImpuesto, [FromQuery] bool Activo = true)
        {
            var response = await _bs.Bs_ProductoImpuesto_Guardar(IdEmpresa, IdProducto, IdImpuesto, Activo);
            return response.Ok ? Ok(response) : BadRequest(response);
        }
    }
}
