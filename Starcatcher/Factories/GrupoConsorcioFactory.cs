using Starcatcher.DTOs;
using Starcatcher.Entities;
using Starcatcher.Services;

namespace Starcatcher.Factories
{
    public class GrupoConsorcioFactory
    {
        public static GrupoConsorcio CriarGrupo(GrupoConsorcioDTOEntry grupo)
        {
            //regra de negocio, vai receber o valor final
            decimal valorFinalDeCotaComTaxa = CalcularValorFinalComTaxaDeAdministracao(grupo.ValorFinalPorCota, grupo.TaxaDeAdministracao);

            GrupoConsorcio result = new(grupo.Nome, (grupo.ValorFinalPorCota * grupo.QuantidadeDeCotas), grupo.TaxaDeAdministracao, grupo.QuantidadeDeCotas, (valorFinalDeCotaComTaxa * grupo.QuantidadeDeCotas), grupo.ParcelasPorCota);

            return result;
        }

        private static decimal CalcularValorFinalComTaxaDeAdministracao(decimal valorSemJuros, decimal taxaDeAdministracao)
        {
            //J=1000×0,02×6=R$120

            return valorSemJuros * (1 + taxaDeAdministracao / 100);
        }

        public static List<Cota> GerarCotas( GrupoConsorcio grupo)
        {
            List<Cota> cotas = [];
            int numeroCota = 1;
            while (true)
            {
                if (cotas.Count == grupo.QuantidadeDeParcelas)
                    break;

                cotas.Add(CotaFactory.GerarCota(numeroCota, grupo.Id, grupo.ValorTotalDoGrupoComTaxa, grupo.ValorTotalDoGrupoSemTaxa, grupo.QuantidadeDeCotas, grupo.QuantidadeDeParcelas));
                numeroCota++;
            }
            return cotas;
        }
    }
}