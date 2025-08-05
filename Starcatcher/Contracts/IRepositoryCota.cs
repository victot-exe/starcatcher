using Starcatcher.Entities;

namespace Starcatcher.Contracts
{
    public interface IRepositoryCota
    {
        public Cota Create(int grupoId, int userId);

        public List<Cota> GetAll();

        public Cota GetById(int Id);

        public Cota Update(int id, Cota obj);

        public void Delete(int id);
    }
}