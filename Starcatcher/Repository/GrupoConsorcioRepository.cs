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

        public Dictionary<GrupoConsorcio, bool> Update(int id, GrupoConsorcio grupo)
        {
            var entity = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
            //logica para atualizar apenas os que não vierem null
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
                entity.ValorTaxaAdministrativa = grupo.TaxaAdministrativa;
                alterouValor = true;
            }

            _context.SaveChanges();

            var retorno = new Dictionary<GrupoConsorcio, bool>();
            retorno[entity] = alterouValor;

            return retorno;
        }

        public GrupoConsorcio UpdateListaDeCotas(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
            entity.Cotas.ForEach(
                c =>
                {
                    var cotaUp = cotas.FirstOrDefault(
                        co => co.NumeroCota == c.NumeroCota
                    );
                    c.DataDeAtribuicao = cotaUp.DataDeAtribuicao;
                    c.QteParcelas = cotaUp.QteParcelas;
                    c.ValorDaCartaDeCredito = cotaUp.QteParcelas;
                    c.ValorParcela = cotaUp.ValorParcela;
                    c.ValorDaCartaDeCredito = cotaUp.ValorDaCartaDeCredito;
                    //Valor total é calculada na hora, então não necessita ser atualizada
                });
            _context.SaveChanges();
            return entity;
        }

        public GrupoConsorcio AddListaDeCotas(int id, List<Cota> cotas)
        {
            var entity = _context.Grupos.Find(id) ?? throw new UsuarioNaoEncontrado(id);
            entity.Cotas = cotas;

            _context.SaveChanges();

            return entity;
        }
    }
}