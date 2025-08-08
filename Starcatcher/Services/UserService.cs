using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Starcatcher.Exceptions;

namespace Starcatcher.Services
{
    public class UserService : IServiceUser
    {
        private readonly IRepositoryUser _repository;
        private readonly ValidationExecutor _validations;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IRepositoryUser repository, IPasswordHasher<User> passwordHasher, ValidationExecutor validations)
        {
            _repository = repository;
            _validations = validations;
            _passwordHasher = passwordHasher;
        }


        public UserExitDto Create(UserEntryDto userDto)
        {
            _validations.ExecuteAll(userDto);
            User user = new(userDto.Username, userDto.Password);
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            try
            {
                _repository.Create(user);
            }
            catch (DbUpdateException ex) when (IsUniqueConstraintViolation(ex))
            {
                throw new UsuarioJaExisteException(user.Username);
            }

            return new(user);
        }

        public void Delete(string username)
        {
            _repository.Delete(username);
        }

        public List<UserExitDto> GetAll()
        {
            return [.. _repository.GetAll().Select(
                u=> new UserExitDto(u))];
        }

        public UserExitDto GetByUsername(string username)
        {
            return new(_repository.GetByUsername(username));
        }

        public UserExitDto Update(int id, UserEntryDto user)
        {

            User entity = new(user.Username, user.Password);

            entity.Password = _passwordHasher.HashPassword(entity, entity.Password);

            return new(_repository.Update(id, entity));
        }

        private bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            if (ex.InnerException is SqlException sqlEx)
            return sqlEx.Number == 2601 || sqlEx.Number == 2627;

            return false;
        }
    }
}