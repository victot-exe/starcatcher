using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

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

        [HttpPost("novo-usuario")]
        public User Create([FromBody] UserDTOEntry user)//TODO nao vai ser protegida essa rota
        {
            User userCriado = _service.Create(user);
            return userCriado;
        }

        [HttpPut("{id}")]
        public User Update(int id, [FromBody] UserDTOUpdate user)//TODO protegida
        {
            return _service.Update(id, user);
        }

        [HttpGet]
        public List<string> GetAll()
        {
            return _service.GetAll()//TODO protegida
            .Select(u => u.Username).ToList();
        }

        [HttpGet("{username}")]
        public string GetByUsername(string username)
        {
            return _service.GetByUsername(username).ToString() ?? throw new IdNaoEncontradoException(0);
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            _service.Delete(id);
        }
    }
}