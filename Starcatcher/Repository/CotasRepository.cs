using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class CotaRepository : IRepository<Cota, int>
    {
        private readonly ApplicationDbContext _context;

        public CotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Cota Create(Cota obj)
        {
            _context.Cotas.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var entity = _context.Cotas.Find(id) ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");
            _context.Cotas.Remove(entity);
            _context.SaveChanges();
        }

        public List<Cota> GetAll()
        {
            return [.. _context.Cotas];
        }

        public Cota GetById(int Id)
        {
            return _context.Cotas.Find(Id)
                        ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");
        }

        public Cota Update(int id, Cota obj)
        {
            var entity = _context.Cotas.Find(id) ?? throw new IdNaoEncontradoException("O Id Solicitado não existe");

            // Atualizando as propriedades
            entity.NumeroCota = obj.NumeroCota;
            entity.ValorTotal = obj.ValorTotal;
            entity.ValorParcela = obj.ValorParcela;
            entity.TotalPago = obj.TotalPago;
            entity.DataDeAtribuicao = obj.DataDeAtribuicao;
            entity.GrupoConsorcio = obj.GrupoConsorcio;

            _context.SaveChanges();
            return entity;
        }
    }
}