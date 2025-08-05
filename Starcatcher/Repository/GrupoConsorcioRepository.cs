using Microsoft.Identity.Client;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class GrupoConsorcioRepository : IRepositoryGrupo
    {
        private readonly ApplicationDbContext _context;
        public GrupoConsorcioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public GrupoConsorcio Create(GrupoConsorcio grupo)
        {
            try
            {
                _context.Grupos.Add(grupo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message);
            }
            return grupo;
        }

        public void Delete(int id)
        {
            var entitie = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
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
                        ?? throw new UsuarioNaoEncontrado(id);
        }

        public GrupoConsorcio Update(int id, GrupoConsorcio grupo)
        {
            var entity = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
            //TODO logica para atualizar apenas os que não vierem null
            
            _context.SaveChanges();

            return entity;
        }

        public GrupoConsorcio UpdateList(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
            entity.Cotas = cotas;

            _context.SaveChanges();

            return entity;
        }
    }
}