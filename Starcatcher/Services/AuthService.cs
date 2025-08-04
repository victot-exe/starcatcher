using Starcatcher.Contracts;
using Starcatcher.Entities;

namespace Starcatcher.Services
{
    public class AuthService//TODO talvez usar
    {
        private readonly IRepositoryUser<User, int, Cota> _repository;

        public AuthService(IRepositoryUser<User, int, Cota> repository) {
            _repository = repository;
        }
    }
}