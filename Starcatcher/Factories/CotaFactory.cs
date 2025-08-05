using Starcatcher.Entities;

namespace Starcatcher.Factories
{
    public class CotaFactory
    {
        public static Cota GerarCota(string numeroCota, int idGrupo, decimal valorDaCartaDeCredito, decimal taxaAdministrativa, int quantidadeDeParcelas)
        {
            //total pago = 0
            decimal valorPago = 0;
            bool atribuida = false;
            // definir a data para hoje
            DateOnly dataCriacao = DateOnly.FromDateTime(DateTime.Now);
            //pegar o Id do grupo
            Cota cota = new(
                        numeroCota,
                        idGrupo,
                        CalcularValorDaParcela(valorDaCartaDeCredito, taxaAdministrativa, quantidadeDeParcelas),
                        valorPago,
                        valorDaCartaDeCredito,
                        quantidadeDeParcelas,
                        atribuida,
                        dataCriacao
                        );
            return cota;
        }

        private static decimal CalcularValorDaParcela(decimal valorDaCartaDeCredito, decimal taxaAdministrativa, int quantidadeDeParcelas)
        {
            return valorDaCartaDeCredito * (1 + taxaAdministrativa / 100) / quantidadeDeParcelas;
        }
    }
}