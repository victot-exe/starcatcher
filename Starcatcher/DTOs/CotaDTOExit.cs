using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaDTOExit(//TODO userId e atribuido -> vou precisar para usar no front
                                int Id,
                                string? NumeroCota,
                                decimal? ValorTotal,
                                decimal? Parcela,
                                decimal? TotalPago,
                                DateOnly DataCriacao,
                                int GrupoId
    )
    {
        public CotaDTOExit(Cota cota) : this(cota.Id, cota.NumeroCota, cota.ValorTotal, cota.ValorParcela, cota.TotalPago, cota.DataDeAtribuicao, cota.GrupoConsorcioId){}
    }
}