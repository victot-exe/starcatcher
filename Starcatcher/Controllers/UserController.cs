using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _service;

        public UserController(IServiceUser service)
        {
            _service = service;
        }

        [HttpPost("novo-usuario")]
        public IActionResult Create([FromBody] UserEntryDto user)
        {
            UserExitDto userCriado = _service.Create(user);
            return Created($"user/{userCriado.Username}", userCriado);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserEntryDto user)
        {
            var entity = _service.Update(id, user);

            return Created($"users/{entity.Username}", entity);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{username}")]
        public IActionResult GetByUsername(string username)
        {
            return Ok(_service.GetByUsername(username));
        }//

        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            _service.Delete(id);
        }
    }
}