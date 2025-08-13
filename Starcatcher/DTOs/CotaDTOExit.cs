using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaDTOExit(
                                int Id,
                                string? NumeroCota,
                                decimal? ValorTotal,
                                decimal? Parcela,
                                decimal? TotalPago,
                                DateOnly DataCriacao,
                                int GrupoId,
                                int? UserId,
                                bool? Atribuida
    )
    {
        public CotaDTOExit(Cota cota) : this(cota.Id, cota.NumeroCota, cota.ValorTotal, cota.ValorParcela, cota.TotalPago, cota.DataDeAtribuicao, cota.GrupoConsorcioId, cota.UserId, cota.Atribuida){}
    }
}