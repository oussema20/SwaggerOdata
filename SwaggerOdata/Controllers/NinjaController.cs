using Microsoft.AspNetCore.Mvc;
using SwaggerOdata.Entities;
using SwaggerOdata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Controllers
{
    [Route("api/Ninja")]
    [ApiController]
    public class NinjaController : Controller
    {
        private IGenericService<Ninja> _ninja;

        
        public NinjaController(IGenericService<Ninja> ninja)
        { 
             _ninja= ninja ;
        }
        [HttpGet]
        public async Task<IEnumerable<Ninja>> GetAll()
        {
            var result = await _ninja.GetAll();
            return result;
        }
    }
}
