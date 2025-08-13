using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record UserExitDto(
        int Id,
        string Username,
        List<CotaDTOExit> Cotas
    )
    {
        public UserExitDto(User user) : this(user.Id, user.Username, [.. user.Cotas.Select(
            c=> new CotaDTOExit(c)
        )])
        {
            
        }
    }
}