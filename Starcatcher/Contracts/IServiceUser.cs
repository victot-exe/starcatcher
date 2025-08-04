namespace Starcatcher.Contracts
{
    public interface IServiceUser<T, V, U>
    {
        public T Create(V obj);

        public List<T> GetAll();

        public T GetByUsername(string username);

        public T Update(int id, U obj);

        public void Delete(int id);
    }
}