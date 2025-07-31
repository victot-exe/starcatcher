namespace Starcatcher.Exceptions
{
    public class IdNaoEncontradoException : Exception
    {
        public IdNaoEncontradoException(int id) : base("O id: " + id + " não está disponível"){}
    }
}