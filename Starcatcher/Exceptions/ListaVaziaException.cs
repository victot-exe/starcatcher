using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Exceptions
{
    public class ListaVaziaException : Exception
    {
        public ListaVaziaException() : base("A lista esta vazia")
        {
            
        }
    }
}