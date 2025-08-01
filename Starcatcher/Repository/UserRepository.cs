using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class UserRepository : IRepositoryUser<User, int, Cota>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Create(User obj)
        {
            try
            {
                _context.Users.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message);
            }

            return obj;
        }

        public void Delete(int id)
        {
            var entitie = _context.Users.Find(id) ?? throw new IdNaoEncontradoException(id);
            _context.Users.Remove(entitie);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return [.. _context.Users];
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id)
                        ?? throw new IdNaoEncontradoException(id);
        }

        public User Update(int id, User obj)
        {
            var entity = _context.Users.Find(id) ?? throw new IdNaoEncontradoException(id);
            entity.Username = obj.Username;
            entity.Password = obj.Password;

            _context.SaveChanges();

            return entity;
        }

        public User AdicionarCota(int id, Cota cota)
        {
            var entity = _context.Users.Find(id) ?? throw new IdNaoEncontradoException(id);
            entity.Cotas.Add(cota);
            _context.SaveChanges();
            return entity;
        }
    }
}