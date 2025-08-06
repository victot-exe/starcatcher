using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Starcatcher.Services
{
    public class UserService : IServiceUser
    {
        private readonly IRepositoryUser _repository;

        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IRepositoryUser repository, IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }


        public UserExitDto Create(UserEntryDto userDto)
        {
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