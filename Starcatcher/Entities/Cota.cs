using Starcatcher.DTOs;

namespace Starcatcher.Entities
{

    public class Cota
    {
        public Cota(){}
        public Cota(CotaDTOEntry cota)
        {
            
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