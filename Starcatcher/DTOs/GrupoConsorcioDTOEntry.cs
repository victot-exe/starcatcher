namespace Starcatcher.DTOs
{
    public record GrupoConsorcioDTOEntry(
        string Nome,
        decimal ValorFinalPorCota,
        decimal TaxaDeAdministracao,//total
        int ParcelasPorCota,
        int QuantidadeDeCotas
    )
    {
        
    }
}