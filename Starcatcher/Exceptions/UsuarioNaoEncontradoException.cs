namespace Starcatcher.Exceptions
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException() : base("Usuario e/ou senha incorretos")
        {
            
        }
    }
}