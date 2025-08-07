using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations.Update
{
    public class NomeNaoPodeSerVazioUpdateValidation : IValidation<GrupoConsorcioUpdateDto>
    {
        public void Valid(GrupoConsorcioUpdateDto grupo)
        {
            if (grupo.NomeDoGrupo.IsNullOrEmpty())
                throw new NotValidException("O nome não pode ser vazio");
        }
    }
}