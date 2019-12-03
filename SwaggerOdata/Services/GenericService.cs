using SwaggerOdata.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> _repo;

        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
