using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starcatcher.Exceptions
{
    public class UsuarioJaExisteException : Exception
    {
        public UsuarioJaExisteException(string username) : base($"O usuário {username} já está sendo utilizado."){}
    }
}