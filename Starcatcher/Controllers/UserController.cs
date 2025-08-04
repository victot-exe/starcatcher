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
        private readonly IServiceUser<User, UserDTOEntry, UserDTOUpdate> _service;

        public UserController(IServiceUser<User, UserDTOEntry, UserDTOUpdate> service)
        {
            _service = service;
        }

        [HttpPost("novo-usuario")]//não proteger
        public User Create([FromBody] UserDTOEntry user)
        {
            User userCriado = _service.Create(user);
            return userCriado;
        }

        [Authorize]
        [HttpPut("{id}")]//TODO proteger
        public User Update(int id, [FromBody] UserDTOUpdate user)//TODO protegida
        {
            return _service.Update(id, user);
        }

        [Authorize]
        [HttpGet]//proteger
        public List<string> GetAll()
        {
            return _service.GetAll()//TODO protegida
            .Select(u => u.Username).ToList();
        }

        [Authorize]
        [HttpGet("{username}")]//TODO proteger
        public string GetByUsername(string username)
        {
            return _service.GetByUsername(username).ToString() ?? throw new IdNaoEncontradoException(0);
        }

        [Authorize]
        [HttpDelete("{id}")]//TODO proteger
        public void DeleteById(int id)
        {
            _service.Delete(id);
        }
    }
}