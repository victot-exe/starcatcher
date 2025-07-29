namespace Starcatcher.Entities
{

    public class Cota
    {
        public int Id { get; set; }

        public int NumeroCota { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorMensal { get; set; }

        public decimal ValorPago { get; set; }

        public DateOnly DataCriacao { get; set; }

        public int GrupoId { get; set; }
    }
}