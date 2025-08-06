using Microsoft.Identity.Client;
using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaUpdateDto(//Talvez mudar para apenas o valor pago
        decimal? ValorParcela,
        decimal? ValorDaCartaDeCredito,
        int? QteParcelas,
        bool? Atribuida,
        decimal? TotalPago
    )
    {}
}