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

        public GenericService(Persistence.Repositories.IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var serv = await _repo.GetAll();
            return serv;

        }
    }
}
