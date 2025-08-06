using Starcatcher.Contracts;
using Starcatcher.Entities;

namespace Starcatcher.Services
{
    public class AuthService//talvez usar
    {
        private readonly IRepositoryUser _repository;

        public AuthService(IRepositoryUser repository) {
            _repository = repository;
        }
    }
}