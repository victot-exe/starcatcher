using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcatcher.DTOs;

namespace Starcatcher.Contracts
{
    public interface IServiceGrupo
    {
        public GrupoConsorcioExitDto Create(GrupoConsorcioCreateDto grupo);
        public List<GrupoConsorcioExitDto> GetAll();
        public GrupoConsorcioExitDto GetById(int id);
        public GrupoConsorcioExitDto Update(int id, GrupoConsorcioCreateDto obj);
        public void Delete(int id);
    }
}