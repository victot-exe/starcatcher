using Starcatcher.Entities;

namespace Starcatcher.Factories
{
    public class CotaFactory
    {
        public static Cota GerarCota(string numeroCota, int idGrupo, decimal valorDaCartaDeCredito, decimal taxaAdministrativa, int quantidadeDeParcelas)
        {
            
            decimal valorPago = 0;
            bool atribuida = false;
            
            DateOnly dataCriacao = DateOnly.FromDateTime(DateTime.Now);
            
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