using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;

namespace Starcatcher.Repository
{
    public class CotaRepository : IRepositoryCota<Cota, int>
    {
        private readonly ApplicationDbContext _context;

        public CotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Cota Create(int obj)
        {
            Cota result = _context.Cotas
                .FirstOrDefault(c => c.GrupoConsorcioId == obj && !c.Atribuida) ?? throw new IdNaoEncontradoException(obj);
            //query personalizada onde pega o primeiro da lista que está marcado como ativo
            result.Atribuida = true;
            _context.SaveChanges();
            return result;
        }

        public void Delete(int id)
        {
            var entity = _context.Cotas.Find(id) ?? throw new IdNaoEncontradoException(id);
            entity.Atribuida = false;
            _context.SaveChanges();
        }

        public List<Cota> GetAll()
        {
            return [.. _context.Cotas.Where(c => c.Atribuida == true)];
        }

        public Cota GetById(int id)
        {
            return _context.Cotas.Find(id)
                        ?? throw new IdNaoEncontradoException(id);
        }

        public Cota Update(int id, Cota obj)
        {
            var entity = _context.Cotas.Find(id) ?? throw new IdNaoEncontradoException(id);

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