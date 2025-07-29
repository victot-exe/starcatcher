using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Contracts
{
    public interface IService<E, I, O>
    {
        public E Create(I obj);

        public List<E> GetAll();

        public E GetById(O id);

        public E Update(O id, I obj);

        public bool Delete(O id);
    }
}