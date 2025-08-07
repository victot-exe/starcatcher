using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations.UserValidations
{
    public class UsernameNotBlankOrNullValidation : IValidation<UserEntryDto>
    {
        public void Valid(UserEntryDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new NotValidException("O nome de usuário é obrigatório");
        }
    }
}