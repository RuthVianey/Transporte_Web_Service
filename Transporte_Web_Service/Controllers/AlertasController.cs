using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AlertasController : ControllerBase
{
    private readonly AlertasBussines _bussines;
    public AlertasController(AlertasBussines bussines) => _bussines = bussines;
    [HttpGet("listar")]
    public async Task<IActionResult> Listar([FromQuery] int IdEmpresa, [FromQuery] int? IdSucursal = null)
    {
        var response = await _bussines.Listar(IdEmpresa, IdSucursal);
        return response.Ok ? Ok(response) : BadRequest(response);
    }

    [HttpPost("seguimiento")]
    public async Task<IActionResult> Seguimiento([FromBody] Entity_AlertaSeguimiento_Guardar entidad)
    {
        var response = await _bussines.GuardarSeguimiento(entidad);
        return response.Ok ? Ok(response) : BadRequest(response);
    }

    [HttpGet("historial")]
    public async Task<IActionResult> Historial([FromQuery] int IdEmpresa, [FromQuery] string ClaveAlerta)
    {
        var response = await _bussines.Historial(IdEmpresa, ClaveAlerta);
        return response.Ok ? Ok(response) : BadRequest(response);
    }
}
