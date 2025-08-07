using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations.Create
{
    public class QuantidadeDeCotasMaiorDoQueZeroValidation : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupo)
        {
            if (grupo.QuantidadeDeCotas <= 0)
                throw new NotValidException("A quantidade de cotas deve ser maior do que zero");
        }
    }
}