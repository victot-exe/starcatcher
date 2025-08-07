using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.UserValidations
{
    public class PasswordNotBlankOrNullValidation : IValidation<UserEntryDto>
    {
        public void Valid(UserEntryDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new NotValidException("A senha é obrigatória e não pode conter apenas de espaços");
        }
    }
}