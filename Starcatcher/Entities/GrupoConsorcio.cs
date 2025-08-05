namespace Starcatcher.Entities
{
    public class GrupoConsorcio
    {
        public int Id { get; set; }
        public string NomeDoGrupo { get; set; } = string.Empty;
        public decimal ValorTotalDoGrupoSemTaxa { get; set; }
        public List<Cota> Cotas { get; set; } = [];
        public int QuantidadeDeCotas { get; set; }
        public decimal TaxaAdministrativa { get; set; }
        public decimal ValorTaxaAdministrativa { get; set; }//calcular no momento da criação do objeto na factory
        public GrupoConsorcio(string grupo, decimal valorTotalDoGrupoSemTaxa, decimal taxa, int totaldeCotas, decimal valorTaxaAdministrativa)
        {
            NomeDoGrupo = grupo;
            ValorTotalDoGrupoSemTaxa = valorTotalDoGrupoSemTaxa;
            TaxaAdministrativa = taxa;
            QuantidadeDeCotas = totaldeCotas;
            ValorTaxaAdministrativa = valorTaxaAdministrativa;
        }
        public GrupoConsorcio(){}
    }
}

