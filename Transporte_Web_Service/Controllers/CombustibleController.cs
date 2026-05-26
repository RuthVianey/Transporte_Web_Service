using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transporte_Web_Service.Bussines;

namespace Transporte_Web_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CombustibleController : ControllerBase
    {
        private readonly CombustibleBussines _bs;

        public CombustibleController(CombustibleBussines bs)
        {
            _bs = bs;
        }

    }
}
