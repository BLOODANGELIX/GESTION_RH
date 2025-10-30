using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.Repositories
{
    public class RepositorioAsistencia : RepositoryBase, IBaseRepository<RepositorioAsistencia, int>
    {
        public void Add(RepositorioAsistencia modelo)
        {
            throw new NotImplementedException();
        }

        public void Edit(RepositorioAsistencia modelo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepositorioAsistencia> GetAll()
        {
            throw new NotImplementedException();
        }

        public RepositorioAsistencia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

