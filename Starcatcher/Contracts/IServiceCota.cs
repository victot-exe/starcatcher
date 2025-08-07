using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcatcher.DTOs;

namespace Starcatcher.Contracts
{
    public interface IServiceCota
    {
        public CotaDTOExit Create(int grupoId);

        public List<CotaDTOExit> GetAll();

        public CotaDTOExit GetById(int id);

        public CotaDTOExit Update(int id, CotaUpdateDto update);

        public void Delete(int id);
    }
}