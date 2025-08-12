using Microsoft.AspNetCore.Mvc;
using Starcatcher.DTOs;
using Starcatcher.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cotas")]
    public class CotaController : ControllerBase
    {
        private readonly IServiceCota _service;

        public CotaController(IServiceCota service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string Hello()
        {
            return "Hello World!";
        }

        [Authorize]
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            CotaDTOExit result = _service.Create(id);

            return Created("cotas/" + result.Id, result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllCotas()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetCotaById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateCota(int id,[FromBody] CotaUpdateDto cotaNew)
        {
            var result = _service.Update(id, cotaNew);
            return Created("cotas/" + id, result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteCota(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}