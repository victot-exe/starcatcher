using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaDTOUpdate(int NumeroCota,
                                decimal ValorTotal,
                                decimal Parcela,
                                decimal TotalPago,
                                DateOnly DataCriacao,
                                GrupoConsorcio GrupoConsorcio//TODO ver de colocar só o Id do grupo e procutrar o mesmo antes de atualizar
    )
    {
        // public CotaDTOExit(Cota cota) : this(cota.Id, cota.NumeroCota, cota.ValorTotal, cota.Parcela, cota.TotalPago, cota.DataCriacao, cota.GrupoId){}
    }
}