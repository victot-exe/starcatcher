using Microsoft.Identity.Client;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class GrupoConsorcioRepository : IRepositoryGrupo<GrupoConsorcio, int, Cota>//TODO implementar
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
            var entitie = _context.Grupos.Find(id) ?? throw new IdNaoEncontradoException(id);
            _context.Grupos.Remove(entitie);
            _context.SaveChanges();
        }

        public List<GrupoConsorcio> GetAll()
        {
            return [.. _context.Grupos];
        }

        public GrupoConsorcio GetById(int id)
        {
            return _context.Grupos.Find(id)
                        ?? throw new IdNaoEncontradoException(id);
        }

        public GrupoConsorcio Update(int id, GrupoConsorcio obj)
        {
            var entity = _context.Grupos.Find(id) ?? throw new IdNaoEncontradoException(id);
            //TODO logica para atualizar apenas os que não vierem null
            entity.Grupo = obj.Grupo;
            entity.Cotas = obj.Cotas;
            entity.ValorTotalDoGrupoSemTaxa = obj.ValorTotalDoGrupoSemTaxa;
            entity.QuantidadeDeCotas = obj.QuantidadeDeCotas;
            entity.ValorTotalDoGrupoComTaxa = obj.ValorTotalDoGrupoComTaxa;
            entity.QuantidadeDeParcelas = obj.QuantidadeDeParcelas;

            _context.SaveChanges();

            return entity;
        }

        public GrupoConsorcio UpdateList(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Find(id) ?? throw new IdNaoEncontradoException(id);
            entity.Cotas = cotas;

            _context.SaveChanges();

            return entity;
        }
    }
}