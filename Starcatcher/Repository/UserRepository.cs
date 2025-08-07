using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class UserRepository : IRepositoryUser
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var entitie = _context.Users.Find(id) ?? throw new RecursoNaoEncontradoException(id);
            _context.Users.Remove(entitie);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return [.. _context.Users.Include(u => u.Cotas)];
        }

        public User GetByUsername(string username)
        {
            return _context.Users
                    .SingleOrDefault(u => u.Username == username)
                        ?? throw new RecursoNaoEncontradoException(username);
        }

        public User Update(int id, User user)
        {
            var entity = _context.Users.Find(id) ?? throw new RecursoNaoEncontradoException(id);
            if (!string.IsNullOrWhiteSpace(user.Username))
                entity.Username = user.Username;

            if (!string.IsNullOrWhiteSpace(user.Password))
                entity.Password = user.Password;

            _context.SaveChanges();

            return entity;
        }

        public User AdicionarCota(int id, Cota cota)
        {
            var entity = _context.Users.Find(id) ?? throw new RecursoNaoEncontradoException(id);
            entity.Cotas.Add(cota);
            _context.SaveChanges();
            return entity;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id) ?? throw new RecursoNaoEncontradoException(id);
        }
    }
}