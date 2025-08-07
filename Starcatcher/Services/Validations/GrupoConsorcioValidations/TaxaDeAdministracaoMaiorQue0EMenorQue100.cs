using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.GrupoConsorcioValidations
{
    public class TaxaDeAdministracaoMaiorQue0EMenorQue100 : IValidation<GrupoConsorcioCreateDto>
    {
        public void Valid(GrupoConsorcioCreateDto grupo)
        {
            decimal taxa = grupo.TaxaDeAdministracao;
            if (taxa <= 0)
                throw new NotValidException("A taxa de administração deve ser maior do que 0");

            if (taxa >= 100)
                throw new NotValidException("A taxa de administração deve ser menor do que 100");
        }
    }
}