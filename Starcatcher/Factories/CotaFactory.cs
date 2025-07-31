using Starcatcher.Entities;

namespace Starcatcher.Factories
{
    public class CotaFactory
    {
        public static Cota GerarCota(int numeroCota, int idGrupo, decimal valorTotalDoGrupoComTaxa, decimal valorTotalDoGrupoSemTaxa, int quantidadeDeCotas, int quantidadeDeParcelas)
        {
            //pegar o valor da carta de credito
            decimal valorDaCartaDeCredito = valorTotalDoGrupoSemTaxa / quantidadeDeCotas;
            //pegar o numero da parcela
            decimal valorParcela = valorTotalDoGrupoComTaxa / quantidadeDeCotas / quantidadeDeParcelas;
            //total pago = 0
            decimal valorPago = 0;
            bool atribuida = false;
            // definir a data para hoje
            DateOnly dataCriacao = DateOnly.FromDateTime(DateTime.Now);
            //pegar o Id do grupo
            Cota cota = new(
                numeroCota, idGrupo, valorParcela, valorPago, valorDaCartaDeCredito, quantidadeDeParcelas, atribuida, dataCriacao
            );
            return cota;
        }
    }
}