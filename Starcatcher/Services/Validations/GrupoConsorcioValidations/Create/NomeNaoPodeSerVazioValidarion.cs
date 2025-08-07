using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations.Create
{
    public class NomeNaoPodeSerVazioValidarion : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupo)
        {
            string nomeDoGrupo = grupo.NomeGrupo;
            if (nomeDoGrupo.IsNullOrEmpty() || string.IsNullOrWhiteSpace(nomeDoGrupo))
                throw new NotValidException("O nome do grupo não pode estar em branco");
        }
    }
}