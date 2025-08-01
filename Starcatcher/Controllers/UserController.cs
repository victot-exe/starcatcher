using Microsoft.AspNetCore.Mvc;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IService<User, UserDTOEntry, int, UserDTOUpdate> _service;

        public UserController(IService<User, UserDTOEntry, int, UserDTOUpdate> service)
        {
            _service = service;
        }

        [HttpPost]
        public User Create([FromBody] UserDTOEntry user)
        {
            User userCriado = _service.Create(user);
            return userCriado;
        }
    }
}