using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations
{
    public class GrupoNotNullValidation : IValidation<CotaCreateDto>
    {
        public void Valid(CotaCreateDto obj)
        {
            if (obj.GrupoId <= 0)
                throw new NotValidException("O id do grupo deve ser enviado");
        }
    }
}