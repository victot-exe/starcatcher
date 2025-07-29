using Microsoft.AspNetCore.Mvc;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cota")]
    public class CotaController : ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }
    }
}