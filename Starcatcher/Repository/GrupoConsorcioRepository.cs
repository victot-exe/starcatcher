using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;
using Starcatcher.Exceptions;
using Starcatcher.Factories;

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
            var entitie = _context.Grupos.Find(id) ?? throw new RecursoNaoEncontradoException(id);
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
                        ?? throw new RecursoNaoEncontradoException(id);
        }

        public Dictionary<GrupoConsorcio, bool> Update(int id, GrupoConsorcio grupo)
        {
            var entity = _context.Grupos.Find(id) ?? throw new RecursoNaoEncontradoException(id);

            bool alterouValor = false;

            if (!grupo.NomeDoGrupo.IsNullOrEmpty())
                entity.NomeDoGrupo = grupo.NomeDoGrupo;

            if (grupo.ValorTotalDoGrupoSemTaxa.HasValue)
            {
                entity.ValorTotalDoGrupoSemTaxa = grupo.ValorTotalDoGrupoSemTaxa;
                alterouValor = true;
            }
            if (grupo.QuantidadeDeCotas.HasValue)
            {
                entity.QuantidadeDeCotas = grupo.QuantidadeDeCotas;
                alterouValor = true;
            }

            if (grupo.TaxaAdministrativa.HasValue)
            {
                entity.TaxaAdministrativa = grupo.TaxaAdministrativa;
                alterouValor = true;
            }

            if (grupo.ValorTaxaAdministrativa.HasValue)
            {
                entity.ValorTaxaAdministrativa = grupo.ValorTaxaAdministrativa;
                alterouValor = true;
            }

            _context.SaveChanges();

            var retorno = new Dictionary<GrupoConsorcio, bool>
            {
                [entity] = alterouValor
            };

            return retorno;
        }

        public GrupoConsorcio UpdateListaDeCotas(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Include(g => g.Cotas).IgnoreQueryFilters().FirstOrDefault(g => g.Id ==id) ?? throw new RecursoNaoEncontradoException(id);
            if (entity.Cotas.Count != cotas.Count)
                throw new NotValidException($"O numero de cotas por grupo não pode ser alterado.\nO numero deve ser: {entity.Cotas.Count}");
            
            entity.Cotas.ForEach(
                c =>
                {
                    var cotaUp = cotas.FirstOrDefault(
                        co => co.NumeroCota == c.NumeroCota
                    );
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    c.DataDeAtribuicao = cotaUp.DataDeAtribuicao;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    c.QteParcelas = cotaUp.QteParcelas;
                    c.ValorDaCartaDeCredito = cotaUp.ValorDaCartaDeCredito;
                    c.ValorParcela = cotaUp.ValorParcela;
                });
            _context.SaveChanges();
            return entity;
        }

        public GrupoConsorcio AddListaDeCotas(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Find(id) ?? throw new RecursoNaoEncontradoException(id);
            entity.Cotas = cotas;

            _context.SaveChanges();

            return entity;
        }
    }
}