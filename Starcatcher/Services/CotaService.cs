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
        private readonly ValidationExecutor _validations;
        public CotaService(IRepository<Cota, int> repository, ValidationExecutor validations)
        {
            _repository = repository;
            _validations = validations;
        }

        public CotaDTOExit Create(CotaDTOEntry obj)
        {
            //TODO criar a cota vai ser procurar uma cota e pegar a primeira que bata com os requisitos e não esteja atribuida a um usuario
            //TODO Regras de negocio para a criação de cotas -> tentar usar algo semelhante a reflections
            //TODO regra para gerar o numero da cota, verificar se ainda tem cota disponível no grupo selecionado
            //TODO regra que vai pegar o valor padrão para cotas naquele grupo e pegar os dados como, valor da parcela, definir o total pago como 0, 
            _validations.ExecuteAll(obj);//<- teoricamente aqui estão as validações, não testado ainda
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