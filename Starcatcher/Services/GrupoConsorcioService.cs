using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Factories;

namespace Starcatcher.Services
{
    public class GrupoConsorcioService : IServiceGrupo
    {
        private readonly IRepositoryGrupo _repository;

        private readonly ValidationExecutor _validations;

        public GrupoConsorcioService(IRepositoryGrupo repository, ValidationExecutor validations)
        {
            _repository = repository;
            _validations = validations;
        }

        public GrupoConsorcioExitDto Create(GrupoConsorcioCreateDto grupoCreate)
        {
            //TODO validar os dados enviados
            _validations.ExecuteAll(grupoCreate);
            GrupoConsorcio result =_repository.Create(GrupoConsorcioFactory.CriarGrupo(grupoCreate));
            _repository.AddListaDeCotas(result.Id, GrupoConsorcioFactory.GerarCotas(result.Id, grupoCreate));
            return new(result);
        }

        public GrupoConsorcioExitDto Update(int id, GrupoConsorcioCreateDto grupo)//TODO um dto para atualização que não permite atualizar o numero de cotas
        {
            //TODO validar os dados enviados
            GrupoConsorcio grupoUp = GrupoConsorcioFactory.CriarGrupo(grupo);
            var retorno = _repository.Update(id, grupoUp);
            if (retorno.First().Value)
                _repository.UpdateListaDeCotas(id, GrupoConsorcioFactory.GerarCotas(id, grupo));

            return new(grupoUp);
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
    }
}