using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerOdata.Entities;
using SwaggerOdata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Controllers
{
    //[Route("api/Ninja")]
    //[ApiController]
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Ninja")]
    public class NinjaController : ODataController
    {
        private IGenericService<Ninja> _ninja;

        
        public NinjaController(IGenericService<SwaggerOdata.Entities.Ninja> ninja)
        { 
             _ninja= ninja ;
        }
        //[HttpGet]
        [ODataRoute()]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public async Task<IEnumerable<SwaggerOdata.Entities.Ninja>> GetAll()
        {
            var result = await _ninja.GetAll();
            return result;
        }
    }
}
