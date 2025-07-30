using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException(string mensage) : base(mensage) { }
    }
}