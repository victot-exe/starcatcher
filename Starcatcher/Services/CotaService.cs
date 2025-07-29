using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Repository;

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
            Cota created = _repository.Create(new Cota(obj, DateOnly.FromDateTime(DateTime.Now)));

            return new CotaDTOExit(created);
        }

        public bool Delete(int id)
        {
            try//TODO verificar se é a melhor maneira ou se tem melhores, um handler personalizado e automatico como no spring
            {
                _repository.Delete(id);
            }
            catch (Exception)//TODO trocar pela exceção personalizada que eu vou fazer
            {
                return false;
            }
            return true;
        }

        public List<CotaDTOExit> GetAll()
        {
            return [.. _repository.GetAll().Select(c => new CotaDTOExit(c))];//TODO fazer verificação para o caso de a lista estar vazia e lançar a exceção
        }

        public CotaDTOExit GetById(int id)
        {
            try
            {
                return new(_repository.GetById(id));
            }
            catch
            {
                throw new Exception();//TODO Tratar melhor este erro
            }
        }

        public CotaDTOExit Update(int id, CotaDTOUpdate obj)
        {
            //TODO regras de negocio usar reflections ou algo parecido
            Cota cota = new(obj);
            return new(_repository.Update(id, cota));
        }
    }
}