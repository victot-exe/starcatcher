using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Exceptions;

namespace Starcatcher.Services
{
    public class CotaService : IService<CotaDTOExit, int, int, CotaDTOUpdate>
    {
        private readonly IRepository<Cota, int> _repository;
        private readonly ValidationExecutor _validations;
        public CotaService(IRepository<Cota, int> repository, ValidationExecutor validations)
        {
            _repository = repository;
            _validations = validations;
        }

        public CotaDTOExit Create(int obj)
        {
            
            _validations.ExecuteAll(obj);
            Cota created = _repository.Create(obj);//TODO no repository pesquisar as cotas disponíveis no repository

            return new CotaDTOExit(created);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<CotaDTOExit> GetAll()
        {
            List<CotaDTOExit> saida = [.. _repository.GetAll().Select(c => new CotaDTOExit(c))];//TODO fazer verificação para o caso de a lista estar vazia e lançar a exceção
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

        public CotaDTOExit Update(int id, CotaDTOUpdate obj)
        {
            //TODO regras de negocio usar reflections ou algo parecido
            Cota cota = new(obj);
            return new(_repository.Update(id, cota));
        }
    }
}