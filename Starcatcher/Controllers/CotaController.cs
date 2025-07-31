using Microsoft.AspNetCore.Mvc;
using Starcatcher.Services;
using Starcatcher.DTOs;
using Starcatcher.Contracts;
using Starcatcher.Entities;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cotas")]
    public class CotaController : ControllerBase//TODO testar os retornos para IActionResult
    {
        private readonly IService<CotaDTOExit, int, int, CotaDTOUpdate> _service;

        public CotaController(IService<CotaDTOExit, int, int, CotaDTOUpdate> service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string Hello()
        {
            return "Hello World!";
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            //USando a reflection aqui

            CotaDTOExit result = _service.Create(id);

            return Created("/" + result.Id, result);
        }

        [HttpGet]
        public IActionResult GetAllCotas()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCotaById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCota(int id,[FromBody] CotaDTOUpdate cotaNew)
        {
            _service.Update(id, cotaNew);
            return Created("/" + id, cotaNew);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCota(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}