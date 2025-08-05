using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("grupos")]
    public class GrupoConsorcioController : ControllerBase
    {
        private readonly IService<GrupoConsorcio, GrupoConsorcioCreateDto, int, GrupoConsorcioCreateDto> _service;
        public GrupoConsorcioController(IService<GrupoConsorcio, GrupoConsorcioCreateDto, int, GrupoConsorcioCreateDto> service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string hello()
        {
            return "GrupoConsorcioController Works!";
        }

        [Authorize]
        [HttpPost]//proteger
        public IActionResult Create(GrupoConsorcioCreateDto grupo)
        {
            GrupoConsorcio result = _service.Create(grupo);
            return Created("/" + result.Id, result);
        }

        [Authorize]
        [HttpGet]//proteger
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]//proteger
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
        //TODO deletar
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}