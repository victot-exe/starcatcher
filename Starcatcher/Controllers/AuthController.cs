using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Starcatcher.DTOs;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryUser _repository;

        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IConfiguration configuration, IRepositoryUser repository, IPasswordHasher<User> passwordHasher)
        {
            _configuration = configuration;
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]//não proteger
        public IActionResult Login([FromBody] LoginDTOEntry user)
        {
            var entity = _repository.GetByUsername(user.Username) ?? throw new UsuarioNaoEncontradoException();
            var result = _passwordHasher.VerifyHashedPassword(entity, entity.Password, user.Password);
            if (result == PasswordVerificationResult.Success)
            {
                var token = GenerateJwtToken(entity);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));//aqui
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "meudominio",
                audience: "meudominio",
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}