using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations.Create
{
    public class ParcelasPorCotaMaiorDoQueZeroValidation : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupo)
        {
            if (grupo.ParcelasPorCota <= 0)
                throw new NotValidException("O numero de parcelas por cota deve ser maior do que 0");
        }
    }
}