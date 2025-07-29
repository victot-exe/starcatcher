using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Contracts
{
    public interface IValidation<T>
    {
        public void Valid(T obj);
    }
}