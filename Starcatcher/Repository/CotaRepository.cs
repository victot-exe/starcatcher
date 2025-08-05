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
            Cota result = _context.Cotas //query personalizada onde pega o primeiro da lista que está marcado como ativo
                .FirstOrDefault(c => c.GrupoConsorcioId == obj && c.Atribuida != true) ?? throw new UsuarioNaoEncontrado(obj);
            
            result.Atribuida = true;
            result.UserId = userId;
            _context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            var entity = _context.Cotas.Find(id) ?? throw new UsuarioNaoEncontrado(id);
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
                        ?? throw new UsuarioNaoEncontrado(id);
        }

        public Cota Update(int id, Cota cotaUpdate)
        {
            var entity = _context.Cotas.Find(id) ?? throw new UsuarioNaoEncontrado(id);

            if (cotaUpdate.ValorParcela.HasValue)
                entity.ValorParcela = cotaUpdate.ValorParcela;

            if (cotaUpdate.ValorDaCartaDeCredito.HasValue)
                entity.ValorDaCartaDeCredito = cotaUpdate.ValorDaCartaDeCredito;

            if (cotaUpdate.QteParcelas.HasValue)
                entity.QteParcelas = cotaUpdate.QteParcelas;

            if (cotaUpdate.Atribuida.HasValue)
                entity.Atribuida = cotaUpdate.Atribuida;

            if (cotaUpdate.TotalPago.HasValue)
                entity.TotalPago = cotaUpdate.TotalPago;

            _context.SaveChanges();
            return entity;
        }
    }
}