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
        private readonly IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcio> _service;
        public GrupoConsorcioController(IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcio> service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string hello()
        {
            return "GrupoConsorcioController Works!";
        }

        [HttpPost]
        public IActionResult Create(GrupoConsorcioDTOEntry grupo)
        {
            GrupoConsorcio result = _service.Create(grupo);
            return Created("/" + result.Id, result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
    }
}