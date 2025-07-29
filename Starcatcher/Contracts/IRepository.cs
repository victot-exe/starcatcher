namespace Starcatcher.Contracts
{
    public interface IRepository <T, I>
    {
        public T Create(T obj);

        public List<T> GetAll();

        public T GetById(I Id);

        public T Update(I id, T obj);

        public void Delete(I id);
    }
}