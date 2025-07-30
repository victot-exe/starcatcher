using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Exceptions;

namespace Starcatcher.Services
{
    public class CotaService : IService<CotaDTOExit, CotaDTOEntry, int, CotaDTOUpdate>
    {
        private readonly IRepository<Cota, int> _repository;
        public CotaService(IRepository<Cota, int> repository)
        {
            _repository = repository;
        }

        public CotaDTOExit Create(CotaDTOEntry obj)
        {
            //TODO Regras de negocio para a criação de cotas -> tentar usar algo semelhante a reflections
            //TODO procurar um grupo pelo id ao inves de criar diretamente no construtor
            Cota created = _repository.Create(new Cota(obj, DateOnly.FromDateTime(DateTime.Now), new GrupoConsorcio()));

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