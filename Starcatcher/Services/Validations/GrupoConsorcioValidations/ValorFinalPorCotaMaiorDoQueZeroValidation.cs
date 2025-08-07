using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations
{
    public class ValorFinalPorCotaMaiorDoQueZeroValidation : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupoCreate)
        {
            if (grupoCreate.ValorFinalPorCota <= 0)
                throw new NotValidException("O valor final por cota deve ser maior do que zero");
        }
    }
}