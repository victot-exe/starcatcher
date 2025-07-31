using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.DTOs;
using Starcatcher.Factories;

namespace Starcatcher.Services
{
    public class GrupoConsorcioService : IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcio>
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
            throw new NotImplementedException();
        }

        public List<GrupoConsorcio> GetAll()
        {
            throw new NotImplementedException();
        }

        public GrupoConsorcio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public GrupoConsorcio Update(int id, GrupoConsorcio obj)
        {
            throw new NotImplementedException();
        }
    }
}