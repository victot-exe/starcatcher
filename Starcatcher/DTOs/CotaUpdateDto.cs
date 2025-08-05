using Microsoft.Identity.Client;
using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaUpdateDto(
        decimal? ValorParcela,
        decimal? ValorDaCartaDeCredito,
        int? QteParcelas,
        bool? Atribuida,
        decimal? TotalPago
    )
    {}
}