using Starcatcher.DTOs;
using Starcatcher.Entities;

namespace Starcatcher.Contracts
{
    public interface IServiceUser
    {
        public User Create(UserDTOEntry user);

        public List<User> GetAll();

        public User GetByUsername(string username);

        public User Update(int id, UserDTOEntry obj);

        public void Delete(int id);
    }
}