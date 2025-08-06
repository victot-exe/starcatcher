using Microsoft.Identity.Client;
using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaUpdateDto(//TODO talvez mudar para um que altere apenas o valor pago
        decimal? ValorParcela,
        decimal? ValorDaCartaDeCredito,
        int? QteParcelas,
        bool? Atribuida,
        decimal? TotalPago
    )
    {}
}