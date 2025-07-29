using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;

namespace Starcatcher.Repository
{
    public class CotasRepository : IRepository<Cota, int>
    {
        private readonly ApplicationDbContext _context;

        public CotasRepository(ApplicationDbContext context)
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
            var entity = _context.Cotas.Find(id) ?? throw new Exception("O Id Solicitado não existe");
            _context.Cotas.Remove(entity);
            _context.SaveChanges();
        }

        public List<Cota> GetAll()
        {
            return [.. _context.Cotas];
        }

        public Cota GetById(int Id)
        {
            var entitie = _context.Cotas.Find(Id) ?? throw new Exception("O Id Solicitado não existe");
            return entitie;
        }

        public Cota Update(int id, Cota obj)
        {
            var entity = _context.Cotas.Find(id) ?? throw new Exception("O Id Solicitado não existe");

            // Atualizando as propriedades
            entity.NumeroCota = obj.NumeroCota;
            entity.ValorTotal = obj.ValorTotal;
            entity.ValorMensal = obj.ValorMensal;
            entity.ValorPago = obj.ValorPago;
            entity.DataCriacao = obj.DataCriacao;
            entity.GrupoId = obj.GrupoId;

            _context.SaveChanges();
            return entity;
        }
    }
}