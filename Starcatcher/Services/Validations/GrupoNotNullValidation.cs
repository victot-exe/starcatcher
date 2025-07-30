using Starcatcher.Contracts;
using Starcatcher.DTOs;
using Starcatcher.Exceptions;

namespace Starcatcher.Services.Validations
{
    public class GrupoNotNullValidation : IValidation<CotaDTOEntry>
    {
        public void Valid(CotaDTOEntry obj)
        {
            if (obj.GrupoId <= 0)
                throw new NotValidException("O id do grupo deve ser enviado");
        }
    }
}