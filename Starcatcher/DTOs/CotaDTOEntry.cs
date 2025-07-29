using System.ComponentModel.DataAnnotations;

namespace Starcatcher.DTOs
{
    public record CotaDTOEntry(
        [Required]int NumeroCota,
        [Required]int GrupoId)
    {
        
    }
}