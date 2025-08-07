namespace Starcatcher.DTOs
{
    public record GrupoConsorcioUpdateDto(
        string? NomeDoGrupo,
        decimal? ValorFinalPorCota,
        decimal? TaxaAdministrativa
    ){}
}