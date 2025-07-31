using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Contracts
{
    public interface IRepositoryGrupo<T, I, L>
    {
        public T Create(T obj);

        public List<T> GetAll();

        public T GetById(I Id);

        public T Update(I id, T obj);

        public void Delete(I id);

        public T UpdateList(I id, List<L> list);
    }
}