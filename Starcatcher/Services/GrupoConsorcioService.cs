using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Factories;

namespace Starcatcher.Services
{
    public class GrupoConsorcioService : IServiceGrupo
    {
        private readonly IRepositoryGrupo _repository;

        public GrupoConsorcioService(IRepositoryGrupo repository)
        {
            _repository = repository;
        }

        public GrupoConsorcioExitDto Create(GrupoConsorcioCreateDto cotaCreate)
        {
            //TODO validar os dados enviados
            GrupoConsorcio result =_repository.Create(GrupoConsorcioFactory.CriarGrupo(cotaCreate));
            _repository.UpdateList(result.Id, GrupoConsorcioFactory.GerarCotas(result.Id, cotaCreate));
            return new();//TODO arrumar a saida correta
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<GrupoConsorcioExitDto> GetAll()
        {
            return [.. _repository.GetAll().Select(c=> new GrupoConsorcioExitDto(c))];
        }

        public GrupoConsorcioExitDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return new(entity);
        }

        public GrupoConsorcioExitDto Update(int id, GrupoConsorcioUpdateDto grupo)
        {
            GrupoConsorcio grupoUp = new();//TODO arrumar a classe do DTOUpdate
            return new(_repository.Update(id, grupoUp));
        }
    }
}