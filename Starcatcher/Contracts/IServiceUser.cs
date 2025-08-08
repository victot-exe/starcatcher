using Starcatcher.DTOs;
using Starcatcher.Entities;

namespace Starcatcher.Contracts
{
    public interface IServiceUser
    {
        public UserExitDto Create(UserEntryDto user);

        public List<UserExitDto> GetAll();

        public UserExitDto GetByUsername(string username);

        public UserExitDto Update(int id, UserEntryDto obj);

        public void Delete(string id);
    }
}