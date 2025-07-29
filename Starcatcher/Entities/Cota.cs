using Starcatcher.DTOs;

namespace Starcatcher.Entities
{

    public class Cota
    {
        public Cota(){}
        public Cota(CotaDTOEntry cota)
        {
            NumeroCota = cota.NumeroCota;
            ValorTotal = cota.ValorTotal;
            Parcela = cota.Parcela;
            TotalPago = cota.TotalPago;
            DataCriacao = cota.DataCriacao;
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