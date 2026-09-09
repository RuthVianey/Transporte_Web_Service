using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuditoriaController : ControllerBase
{
    private readonly AuditoriaBussines _business;
    public AuditoriaController(AuditoriaBussines business) => _business = business;

    [HttpGet("listar")]
    public async Task<IActionResult> Listar([FromQuery] int IdEmpresa, [FromQuery] DateTime? FechaInicio, [FromQuery] DateTime? FechaFin, [FromQuery] string? Modulo)
    {
        var response = await _business.Listar(IdEmpresa, FechaInicio, FechaFin, Modulo);
        return response.Ok ? Ok(response) : BadRequest(response);
    }
}
