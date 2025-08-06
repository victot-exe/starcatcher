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

        public GrupoConsorcioExitDto Create(GrupoConsorcioCreateDto grupoCreate)
        {
            //TODO validar os dados enviados
            GrupoConsorcio result =_repository.Create(GrupoConsorcioFactory.CriarGrupo(grupoCreate));//Ta criando um usuario por cota
            _repository.AddListaDeCotas(result.Id, GrupoConsorcioFactory.GerarCotas(result.Id, grupoCreate));
            return new(result);
        }

        public GrupoConsorcioExitDto Update(int id, GrupoConsorcioCreateDto grupo)
        {
            //TODO validar os dados enviados
            // a logica para atualizar tudo do grupo as cotas e tal, mas apenas se alterar o valor, taxa, parcela ou numero de cotas
            GrupoConsorcio grupoUp = GrupoConsorcioFactory.CriarGrupo(grupo);//Atualiza os dados do grupo com o mesmo processo de criação do grupo.
            //para para atualizar as cotas precisamos pegar a lista de cotas do grupoUp, percorrer a lista e atualizar apenas os valores monetarios e não os outros.
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