namespace Starcatcher.Entities
{
    public class GrupoConsorcio
    {
        public int Id { get; set; }

        public string Grupo { get; set; } = "";

        public decimal ValorMensal { get; set; }

        public List<Cota> Cotas { get; set; } = [];
    }
}

