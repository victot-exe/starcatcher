using Microsoft.AspNetCore.Mvc;
using Starcatcher.DTOs;
using Starcatcher.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cotas")]
    public class CotaController : ControllerBase//testar os retornos para IActionResult
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
            //USando a reflection aqui

            CotaDTOExit result = _service.Create(id);

            return Created("cotas/" + result.Id, result);
        }

        [Authorize]
        [HttpGet]//proteger
        public IActionResult GetAllCotas()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]//proteger
        public IActionResult GetCotaById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Authorize]
        [HttpPut("{id}")]//proteger
        public IActionResult UpdateCota(int id,[FromBody] CotaUpdateDto cotaNew)
        {
            _service.Update(id, cotaNew);
            return Created("cotas/" + id, cotaNew);
        }

        [Authorize]
        [HttpDelete("{id}")]//proteger
        public IActionResult DeleteCota(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}