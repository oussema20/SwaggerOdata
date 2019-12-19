using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Persistence.Repositories
{
    public interface IGenericRepository<T>where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void Add(T obj);
        void SaveChanges();
        void Delete(object id);
    }
}
