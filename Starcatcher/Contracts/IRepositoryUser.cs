namespace Starcatcher.Contracts
{
    public interface IRepositoryUser<T, I, E>
    {
        public T Create(T obj);
        public List<T> GetAll();
        public T GetById(I Id);
        public T Update(I id, T obj);
        public void Delete(I id);
        public T AdicionarCota(I id, E cota);
    }
}