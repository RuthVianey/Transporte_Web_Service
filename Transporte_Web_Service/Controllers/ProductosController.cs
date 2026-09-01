using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosBussines _bs;

        public ProductosController(ProductosBussines bs)
        {
            _bs = bs;
        }

        [HttpGet("listaDatos_Producto_Listar")]
        public async Task<IActionResult> Producto_Listar([FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] bool SoloActivos = true, [FromQuery] string? TextoBusqueda = null)
        {
            var response = await _bs.Bs_Producto_Listar(IdEmpresa, IdSucursal, SoloActivos, TextoBusqueda);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Producto_ObtenerPorId")]
        public async Task<IActionResult> Producto_ObtenerPorId([FromQuery] int IdProducto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Producto_ObtenerPorId(IdProducto, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Producto_Guardar")]
        public async Task<IActionResult> Producto_Guardar([FromQuery] int? IdProducto, [FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal, [FromQuery] string? Clave, [FromQuery] string Descripcion, [FromQuery] string? UnidadMedida, [FromQuery] string? ClaveSAT, [FromQuery] bool MaterialPeligroso = false, [FromQuery] bool Activo = true)
        {
            var response = await _bs.Bs_Producto_Guardar(IdProducto, IdEmpresa, IdSucursal, Clave, Descripcion, UnidadMedida, ClaveSAT, MaterialPeligroso, Activo);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("listaDatos_Producto_Desactivar")]
        public async Task<IActionResult> Producto_Desactivar([FromQuery] int IdProducto, [FromQuery] int IdEmpresa)
        {
            var response = await _bs.Bs_Producto_Desactivar(IdProducto, IdEmpresa);
            if (!response.Ok) return BadRequest(response);
            return Ok(response);
        }
    }
}
