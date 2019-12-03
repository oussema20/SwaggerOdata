using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
