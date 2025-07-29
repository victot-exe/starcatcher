using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcatcher.Contracts;
using Starcatcher.Entities;
using Starcatcher.Entities.Context;

namespace Starcatcher.Repository
{
    public class CotasRepository : IRepository<Cota, int>
    {
        //ApplicationDbContext _dbContext = new();TODO ARRUMAR
        public Cota Create(Cota obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cota> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cota GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Cota Update(int id, Cota obj)
        {
            throw new NotImplementedException();
        }
    }
}