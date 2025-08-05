namespace Starcatcher.DTOs
{
    public record GrupoConsorcioCreateDto(
        string NomeGrupo,
        decimal ValorFinalPorCota,
        decimal TaxaDeAdministracao,//total
        int ParcelasPorCota,
        int QuantidadeDeCotas
    )
    {
        
    }
}