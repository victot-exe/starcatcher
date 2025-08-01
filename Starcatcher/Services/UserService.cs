using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.AspNetCore.Identity;

namespace Starcatcher.Services
{
    public class UserService : IService<User, UserDTOEntry, int, UserDTOUpdate>
    {
        private readonly IRepositoryUser<User, int, Cota> _repository;

        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IRepositoryUser<User, int, Cota> repository, IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }
        public User Create(UserDTOEntry obj)
        {
            User user = new(obj.Username, obj.Password);//TODO logica para fazer o hash da senha no db
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            _repository.Create(user);
            Console.Write(user.ToString());
            return user;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, UserDTOUpdate obj)
        {
            throw new NotImplementedException();
        }
    }
}