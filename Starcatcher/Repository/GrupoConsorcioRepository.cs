using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class GrupoConsorcioRepository : IRepository<GrupoConsorcio, int>//TODO implementar
    {
        private readonly ApplicationDbContext _context;
        public GrupoConsorcioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public GrupoConsorcio Create(GrupoConsorcio obj)
        {
            try
            {
                _context.Grupos.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message);
            }

            return obj;
        }

        public void Delete(int id)
        {
            var entitie = _context.Grupos.Find(id) ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");
            _context.Grupos.Remove(entitie);
            _context.SaveChanges();
        }

        public List<GrupoConsorcio> GetAll()
        {
            return [.. _context.Grupos];
        }

        public GrupoConsorcio GetById(int Id)
        {
            return _context.Grupos.Find(Id)
                        ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");
        }

        public GrupoConsorcio Update(int id, GrupoConsorcio obj)
        {
            var entity = _context.Grupos.Find(id) ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");
            //TODO logica para atualizar apenas os que não vierem null
            entity.Cotas = obj.Cotas;
            entity.Grupo = obj.Grupo;
            entity.ValorMensal = obj.ValorMensal;
            entity.ValorTotalDoGrupo = obj.ValorTotalDoGrupo;

            _context.SaveChanges();

            return entity;
        }

        //ApplicationDbContext _dbContext TODO Arrumar
    }
}