namespace Starcatcher.Exceptions
{
    public class UsuarioNaoEncontrado : Exception
    {
        public UsuarioNaoEncontrado(int id) : base("O id: " + id + " não foi encontrado!"){}
        public UsuarioNaoEncontrado(string username) : base("O username: " + username + " não foi encontrado!"){}
    }
}