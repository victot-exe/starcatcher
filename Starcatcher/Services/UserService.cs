using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Microsoft.AspNetCore.Identity;

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


        public User Create(UserDTOEntry userDto)//TODO saida do DTO
        {
            User user = new(userDto.Username, userDto.Password);//logica para fazer o hash da senha no db
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            _repository.Create(user);
            Console.WriteLine(user.ToString());
            return user;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()//TODO criar dto de saida para usuario onde retorna no id do usuario, o username, e a lista com o numero e o id das cotas que ele tem
        {
            return _repository.GetAll();//TODO converter para o dto que será criado
        }

        public User GetByUsername(string username)
        {
            return _repository.GetByUsername(username);//TODO saida do dto
        }

        public User Update(int id, UserDTOEntry user)
        {
            User entity = new(user.Username, user.Password);
            entity.Password = _passwordHasher.HashPassword(entity, entity.Password);
            return _repository.Update(id, entity);//TODO saida do dto
        }
    }
}