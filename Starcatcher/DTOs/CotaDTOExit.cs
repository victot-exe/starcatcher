using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaDTOExit(int Id,
                                int NumeroCota,
                                decimal ValorTotal,
                                decimal Parcela,
                                decimal TotalPago,
                                DateOnly DataCriacao,
                                int GrupoId
    )
    {
        public CotaDTOExit(Cota cota) : this(cota.Id, cota.NumeroCota, cota.ValorTotal, cota.Parcela, cota.TotalPago, cota.DataCriacao, cota.GrupoId){}
    }
}