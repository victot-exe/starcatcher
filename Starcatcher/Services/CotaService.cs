using System.Security.Claims;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Exceptions;

namespace Starcatcher.Services
{
    public class CotaService : IServiceCota
    {
        private readonly IRepositoryCota _repository;
        private readonly ValidationExecutor _validations;
        private readonly IServiceUser _serviceUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CotaService(IRepositoryCota repository, ValidationExecutor validations, IServiceUser serviceUser, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _validations = validations;
            _serviceUser = serviceUser;
            _httpContextAccessor = httpContextAccessor;
        }

        public CotaDTOExit Create(int grupoId)
        {

            // _validations.ExecuteAll(obj);//TODO definir as validações
            // pegar o Id do usuario
            var user = _httpContextAccessor.HttpContext?.User;
            var claimUserId = user?.FindFirst("userId")?.Value;
            
            if (int.TryParse(claimUserId, out int userId))
            {

                Cota created = _repository.Create(grupoId, userId);//passar o user Id para adicionar ao usuario a lista

                return new CotaDTOExit(created);
            }
            else throw new UnauthorizedAccessException("O usuario nao esta autenticado");
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<CotaDTOExit> GetAll()
        {
            List<CotaDTOExit> saida = [.. _repository.GetAll().Select(c => new CotaDTOExit(c))];//fazer verificação para o caso de a lista estar vazia e lançar a exceção
            if (saida.IsNullOrEmpty())
            {
                throw new ListaVaziaException();
            }
            return saida;
        }

        public CotaDTOExit GetById(int id)
        {
            return new(_repository.GetById(id));
        }

        public CotaDTOExit Update(int id, CotaUpdateDto update)
        {
            //TODO regras de negocio usar reflections ou algo parecido
            Cota cota = new(update);
            return new(_repository.Update(id, cota));
        }
    }
}