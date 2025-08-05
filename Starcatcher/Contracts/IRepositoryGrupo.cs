using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcatcher.Entities;

namespace Starcatcher.Contracts
{
    public interface IRepositoryGrupo
    {
        public GrupoConsorcio Create(GrupoConsorcio grupo);

        public List<GrupoConsorcio> GetAll();

        public GrupoConsorcio GetById(int id);

        public GrupoConsorcio Update(int id, GrupoConsorcio grupo);

        public void Delete(int id);

        public GrupoConsorcio UpdateList(int id, List<Cota> list);
    }
}