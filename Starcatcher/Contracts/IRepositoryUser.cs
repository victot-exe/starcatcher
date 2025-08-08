using Starcatcher.Entities;

namespace Starcatcher.Contracts
{
    public interface IRepositoryUser
    {
        public User Create(User user);
        public List<User> GetAll();
        public User GetByUsername(string username);
        public User GetById(int id);
        public User Update(int id, User obj);
        public void Delete(string username);
        public User AdicionarCota(int id, Cota cota);
    }
}