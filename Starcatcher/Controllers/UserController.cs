using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;
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

        [HttpPost("novo-usuario")]//não proteger
        public IActionResult Create([FromBody] UserDTOEntry user)
        {
            User userCriado = _service.Create(user);//TODO colocar o DTO de saida do usuario aqui
            return Created($"user/{userCriado.Username}", userCriado);
        }

        [Authorize]
        [HttpPut("{id}")]//proteger
        public IActionResult Update(int id, [FromBody] UserDTOEntry user)
        {
            var entity = _service.Update(id, user);//TODO transformar na dto de saida

            return Created($"users/{entity.Username}", entity);
        }

        [Authorize]
        [HttpGet]//proteger
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll().Select(u => u.Username).ToList());//TODO Usar o DTO de saida do usuario aqui
        }

        [Authorize]
        [HttpGet("{username}")]//proteger
        public IActionResult GetByUsername(string username)//TODO User o dto de saida do usuario aqui
        {
            return Ok(_service.GetByUsername(username) ?? throw new UsuarioNaoEncontrado(username));
        }//

        [Authorize]
        [HttpDelete("{id}")]//proteger
        public void DeleteById(int id)
        {
            _service.Delete(id);
        }
    }
}