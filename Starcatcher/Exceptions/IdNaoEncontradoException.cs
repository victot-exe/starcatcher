namespace Starcatcher.Exceptions
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(int id) : base("O id: " + id + " não foi encontrado!"){}
        public RecursoNaoEncontradoException(string username) : base("O username: " + username + " não foi encontrado!"){}
    }
}