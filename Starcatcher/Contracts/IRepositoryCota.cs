namespace Starcatcher.Contracts
{
    public interface IRepositoryCota<T, I>
    {
        public T Create(I obj);

        public List<T> GetAll();

        public T GetById(I Id);

        public T Update(I id, T obj);

        public void Delete(I id);
    }
}