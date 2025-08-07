namespace Starcatcher.DTOs
{
    public record GrupoConsorcioCreateDto(
        string NomeGrupo,
        decimal ValorFinalPorCota,
        decimal TaxaDeAdministracao,
        int ParcelasPorCota,
        int QuantidadeDeCotas
    )
    {}
}