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
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Ninja")]
    public class NinjaController : ODataController
    {
        private IGenericService<Ninja> _ninjaService;

        public NinjaController(IGenericService<SwaggerOdata.Entities.Ninja> ninjaService)
        {
            _ninjaService = ninjaService;
        }

        [ODataRoute()]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public IEnumerable<SwaggerOdata.Entities.Ninja> GetAll()
        {
            var res = _ninjaService.GetAll();
            return res;
        }

    }
}
