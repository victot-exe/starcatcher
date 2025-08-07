using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Services;

namespace Starcatcher.Factories
{
    public class GrupoConsorcioFactory
    {
        public static GrupoConsorcio CriarGrupo(GrupoConsorcioCreateDto grupo)
        {
            decimal valorTotalDoGrupoSemTaxa = CalcularTotalDoGrupoSemTaxa(grupo.ValorFinalPorCota, grupo.QuantidadeDeCotas);

            GrupoConsorcio result = new(
                grupo.NomeGrupo,
                valorTotalDoGrupoSemTaxa,
                grupo.TaxaDeAdministracao,
                grupo.QuantidadeDeCotas,
                CalcularTaxaAdministrativa(valorTotalDoGrupoSemTaxa, grupo.TaxaDeAdministracao));

            return result;
        }

        private static decimal CalcularTotalDoGrupoSemTaxa(decimal valorFinalSemTaxa, int quantidadeDeCotas)
        {
            return valorFinalSemTaxa * quantidadeDeCotas;
        }

        private static decimal CalcularTaxaAdministrativa(decimal valorTotalDoGrupoSemTaxa, decimal taxaDeAdministracao)
        {
            return valorTotalDoGrupoSemTaxa * (taxaDeAdministracao / 100);
        }

        private static decimal CalcularValorFinalComTaxaDeAdministracao(decimal valorSemJuros, decimal taxaDeAdministracao)
        {
            //J=1000×0,02×6=R$120

            return valorSemJuros * (1 + taxaDeAdministracao / 100);
        }

        public static List<Cota> GerarCotas(int grupoId, GrupoConsorcioCreateDto grupo)
        {
            List<Cota> cotas = [];
            int controle = 1;
            string numeroCota = $"G{grupoId:D4}C";
            while (true)
            {
                if (cotas.Count == grupo.QuantidadeDeCotas)
                    break;
                
                string numeroCotaAtual = $"{numeroCota}{controle:D5}";
                cotas.Add(CotaFactory.GerarCota(
                                numeroCotaAtual,
                                grupoId, grupo.ValorFinalPorCota,
                                grupo.TaxaDeAdministracao,
                                grupo.ParcelasPorCota));
                controle++;
            }
            return cotas;
        }
    }
}