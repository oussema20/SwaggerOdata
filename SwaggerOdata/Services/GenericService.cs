using SwaggerOdata.Persistence.Repositories;
using SwaggerOdata.Persistence.Repositories.Ninja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepo;

        public GenericService(IGenericRepository<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public IEnumerable<T> GetAll()
        {
            return _genericRepo.GetAll();
        }

        
    }
}
