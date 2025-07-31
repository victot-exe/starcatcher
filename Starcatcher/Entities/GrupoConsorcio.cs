namespace Starcatcher.Entities
{
    public class GrupoConsorcio
    {
        public int Id { get; set; }
        public string Grupo { get; set; } = "";
        public List<Cota> Cotas { get; set; } = [];
        public decimal ValorTotalDoGrupoSemTaxa { get; set; }
        public int QuantidadeDeCotas { get; set; }
        public decimal ValorTotalDoGrupoComTaxa { get; set; }
        public int QuantidadeDeParcelas { get; set; }

        public decimal TaxaAdministrativa { get; set; }
        public GrupoConsorcio(string grupo, decimal valorTotalDoGrupoSemTaxa, decimal taxa, int totaldeCotas, decimal valorTotalDoGrupoComTaxa, int quantidadeDeParcelas)
        {
            Grupo = grupo;
            ValorTotalDoGrupoSemTaxa = valorTotalDoGrupoSemTaxa;
            TaxaAdministrativa = taxa;
            QuantidadeDeCotas = totaldeCotas;
            ValorTotalDoGrupoComTaxa = valorTotalDoGrupoComTaxa;
            QuantidadeDeParcelas = quantidadeDeParcelas;
        }
        public GrupoConsorcio(){}
    }
}

