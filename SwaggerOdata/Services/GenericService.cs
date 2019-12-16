using SwaggerOdata.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        //private IGenericRepository<T> _repo;
        private readonly IGenericRepository<T> _genericRepo;

        //public GenericService(Persistence.Repositories.IGenericRepository<T> repo)
            public GenericService(IGenericRepository<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var serv = await _genericRepo.GetAll();
            return serv;

        }
    }
}
