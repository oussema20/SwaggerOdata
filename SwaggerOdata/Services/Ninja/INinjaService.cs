using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services.Ninja
{
    public interface INinjaService
    {

        Entities.Ninja GetById(int id);
        Entities.Ninja GetByClan(string clan);
        Entities.Ninja GetByClanAndName(string clan, string name);
    }
}
