using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class CotaRepository : IRepositoryCota
    {
        private readonly ApplicationDbContext _context;

        public CotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Cota Create(int obj, int userId)
        {
            Cota result = _context.Cotas
                .FirstOrDefault(c => c.GrupoConsorcioId == obj && c.Atribuida != true) ?? throw new RecursoNaoEncontradoException(obj);
            
            result.Atribuida = true;
            result.UserId = userId;
            _context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            var entity = _context.Cotas.Find(id) ?? throw new RecursoNaoEncontradoException(id);
            entity.Atribuida = false;
            entity.UserId = null;
            entity.User = null;
            _context.SaveChanges();
        }

        public List<Cota> GetAll()
        {
            return [.. _context.Cotas.Where(c => c.Atribuida == true)];
        }

        public Cota GetById(int id)
        {
            return _context.Cotas.Find(id)
                        ?? throw new RecursoNaoEncontradoException(id);
        }

        public Cota Update(int id, decimal? pagamento)
        {
            var entity = _context.Cotas.Find(id) ?? throw new RecursoNaoEncontradoException(id);

#pragma warning disable CS8629 // Nullable value type may be null.
            if (!(bool)entity.Atribuida)//não vai ser null pois é um valor que já é atribuido automaticamente no momento da criação da cota
                throw new CotaNaoAtribuidaException($"A cota com o Id: {id} não está atribuida a nenhum usuario, portando o valor não pode ser mudado.");
#pragma warning restore CS8629 // Nullable value type may be null.

            entity.TotalPago += pagamento;
            _context.SaveChanges();
            return entity;
        }
    }
}