using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void Add(T obj);
        void Delete(object id);
        T GetById(object id);
        ////void Update( T obj);
    }
}
