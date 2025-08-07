using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations
{
    public class NomeNaoPodeSerVazioValidarion : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupo)
        {
            if (grupo.NomeGrupo.IsNullOrEmpty())
                throw new NotValidException("O nome do grupo não pode estar em branco");
        }
    }
}