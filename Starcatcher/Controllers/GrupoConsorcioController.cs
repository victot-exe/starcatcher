using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.DTOs;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("grupos")]
    public class GrupoConsorcioController : ControllerBase
    {
        private readonly IServiceGrupo _service;
        public GrupoConsorcioController(IServiceGrupo service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string hello()
        {
            return "GrupoConsorcioController Works!";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(GrupoConsorcioCreateDto grupo)
        {
            GrupoConsorcioExitDto result = _service.Create(grupo);
            return Created("/" + result.Id, result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] GrupoConsorcioCreateDto grupo)
        {
            var entity = _service.Update(id, grupo);
            return Created("grupo/" + id, entity);
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}