namespace Starcatcher.DTOs
{
    public record GrupoConsorcioDTOEntry(
        string Nome,
        decimal ValorFinalPorCota,
        decimal TaxaDeAdministracao,//Ao mês
        int ParcelasPorCota,
        int QuantidadeDeCotas
    )
    {
        
    }
}