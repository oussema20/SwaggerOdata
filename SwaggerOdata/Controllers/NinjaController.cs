using Microsoft.AspNetCore.Mvc;
using SwaggerOdata.Entities;
using SwaggerOdata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjaController: Controller
    {
        private IGenericService<Ninja> _ninjaService;

        public NinjaController(IGenericService<SwaggerOdata.Entities.Ninja> ninjaService)
        {
            _ninjaService = ninjaService;
        }

        public IEnumerable<SwaggerOdata.Entities.Ninja> GetAll()
        {
            var res = _ninjaService.GetAll();
            return res;
        }

    }
}
