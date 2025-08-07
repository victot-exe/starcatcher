using Microsoft.Identity.Client;
using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record CotaUpdateDto(
        decimal? Pagamento
    ){}
}