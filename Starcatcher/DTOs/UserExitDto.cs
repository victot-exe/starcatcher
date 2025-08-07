using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record UserExitDto(
        string Username,
        List<CotaDTOExit> Cotas
    )
    {
        public UserExitDto(User user) : this(user.Username, [.. user.Cotas.Select(
            c=> new CotaDTOExit(c)
        )])
        {
            
        }
    }
}