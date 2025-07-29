using Starcatcher.DTOs;

namespace Starcatcher.Entities
{

    public class Cota
    {
        public Cota(){}
        public Cota(CotaDTOEntry cota, DateOnly date)
        {
            NumeroCota = cota.NumeroCota;
            // ValorTotal = cota.ValorTotal; //TODO logica do service para enviar a data
            // Parcela = cota.Parcela; //TODO logica no service para pegar o valor da parcela
            // TotalPago = cota.TotalPago; //TODO provavelmente no momento da criação será 0
            DataCriacao = date; //TODO logica para pegar a data de hoje ou pelo grupo
            GrupoId = cota.GrupoId;
        }

        public Cota(CotaDTOUpdate cota)
        {
            NumeroCota = cota.NumeroCota;
            ValorTotal = cota.ValorTotal; //TODO logica do service para enviar a data
            Parcela = cota.Parcela; //TODO logica no service para pegar o valor da parcela
            TotalPago = cota.TotalPago; //TODO provavelmente no momento da criação será 0
            DataCriacao = cota.DataCriacao; //TODO logica para pegar a data de hoje ou pelo grupo
            GrupoId = cota.GrupoId;
        }
        public int Id { get; set; }

        public int NumeroCota { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal Parcela { get; set; }

        public decimal TotalPago { get; set; }

        public DateOnly DataCriacao { get; set; }

        public int GrupoId { get; set; }
    }
}