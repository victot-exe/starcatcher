using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Starcatcher.Services
{
    public class UserService : IServiceUser<User, UserDTOEntry, UserDTOUpdate>
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
            Console.WriteLine(user.ToString());
            return user;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetByUsername(string username)
        {
            return _repository.GetByUsername(username);
        }

        public User Update(int id, UserDTOUpdate obj)
        {

            User entity = new(obj);
            entity.Password = _passwordHasher.HashPassword(entity, entity.Password);
            return _repository.Update(id, entity);

        }
    }
}