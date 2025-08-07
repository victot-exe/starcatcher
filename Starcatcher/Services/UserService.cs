using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Identity;

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
            _repository.Create(user);

            return new(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
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
    }
}