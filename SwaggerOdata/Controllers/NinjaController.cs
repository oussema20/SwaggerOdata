using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerOdata.Entities;
using SwaggerOdata.Services;
using SwaggerOdata.Services.Ninja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Controllers
{
    [ApiVersion("1.0")]
    //[ODataRoutePrefix("Ninja")]
    public class NinjaController : ODataController
    {
        private IGenericService<Ninja> _ninjaService;
        private INinjaService _customNinjaService;

        public NinjaController(IGenericService<SwaggerOdata.Entities.Ninja> ninjaService, INinjaService customNinjaService)
        {
            _ninjaService = ninjaService;
            _customNinjaService = customNinjaService;
        }

        [ODataRoute("Ninja")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public IEnumerable<SwaggerOdata.Entities.Ninja> GetAll()
        {
            var res = _ninjaService.GetAll();
            return res;
        }

        [ODataRoute("Ninja({key})")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Entities.Ninja), StatusCodes.Status201Created)]
        public SwaggerOdata.Entities.Ninja Get([FromODataUri] int key)
        {
            var res = _customNinjaService.GetById(key);
            return  res;
        }


        [ODataRoute("GetByClan")]
        [HttpGet]
        public SwaggerOdata.Entities.Ninja GetByClan([FromODataUri] string clan)
        {
            var res = _customNinjaService.GetByClan(clan);
            return res;
        }

        [ODataRoute("GetByClanAndName")]
        [HttpGet]
        public SwaggerOdata.Entities.Ninja GetByClanAndName([FromODataUri] string clan, [FromODataUri] string name)
        {
            var res = _customNinjaService.GetByClanAndName(clan,name);
            return res;
        }

    }
}
