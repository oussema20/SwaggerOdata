using SwaggerOdata.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services.Ninja
{
    public class NinjaService :GenericService<SwaggerOdata.Entities.Ninja>
    {
        public NinjaService(IGenericRepository<SwaggerOdata.Entities.Ninja> genericRepo) : base(genericRepo)
        {
           
        }
    }
}
