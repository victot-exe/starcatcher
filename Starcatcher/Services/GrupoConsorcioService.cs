using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Factories;

namespace Starcatcher.Services
{
    public class GrupoConsorcioService : IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcioDTOEntry>
    {
        private readonly IRepositoryGrupo<GrupoConsorcio, int, Cota> _repository;

        public GrupoConsorcioService(IRepositoryGrupo<GrupoConsorcio, int, Cota> repository)
        {
            _repository = repository;
        }

        public GrupoConsorcio Create(GrupoConsorcioDTOEntry obj)
        {
            //TODO validar os dados enviados
            GrupoConsorcio result =_repository.Create(GrupoConsorcioFactory.CriarGrupo(obj));
            _repository.UpdateList(result.Id, GrupoConsorcioFactory.GerarCotas(result));
            return result;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<GrupoConsorcio> GetAll()
        {
            return [.._repository.GetAll()];
        }

        public GrupoConsorcio GetById(int id)
        {
            return _repository.GetById(id);
        }

        public GrupoConsorcio Update(int id, GrupoConsorcioDTOEntry obj)
        {
            GrupoConsorcio grupo = new(
                obj.Nome,
                obj.ValorFinalPorCota * obj.QuantidadeDeCotas,
                obj.TaxaDeAdministracao,
                obj.QuantidadeDeCotas,
                obj.ValorFinalPorCota * (1 + obj.TaxaDeAdministracao / 100),
                obj.ParcelasPorCota
            );
            return _repository.Update(id, grupo);
        }
    }
}