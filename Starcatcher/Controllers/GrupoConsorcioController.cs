using Microsoft.AspNetCore.Mvc;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("grupos")]
    public class GrupoConsorcioController : ControllerBase
    {
        [HttpGet]
        public string hello()
        {
            return "GrupoConsorcioController Works!";
        }
    }
}