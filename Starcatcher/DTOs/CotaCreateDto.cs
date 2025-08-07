using System.ComponentModel.DataAnnotations;

namespace Starcatcher.DTOs
{
    public record CotaCreateDto(
        [Required]int GrupoId)
    {
        
    }
}