using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    //[Route("api/Ninja")]
    //[ApiController]
    [ApiVersion("1.0")]
    //[ODataRoutePrefix("Ninja")]
    public class NinjaController : ODataController
    {
        private IGenericService<Ninja> _ninja;
        private INinjaService _customNinja;

        public NinjaController(IGenericService<SwaggerOdata.Entities.Ninja> ninja, INinjaService customNinja)
        {
            _ninja = ninja;
            _customNinja = customNinja;
        }
        //[HttpGet]
        [ODataRoute("Ninja")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public async Task<IEnumerable<SwaggerOdata.Entities.Ninja>> GetAll()
        {
            var result = await _ninja.GetAll();
            return result;
        }
        [ODataRoute("Ninja")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Ninja obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _ninja.Add(obj);
            return Ok(obj);
        }
        [ODataRoute("Ninja")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _ninja.Delete(id);
            return Ok("done");
        }

        [ODataRoute("Ninja({key})")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Entities.Ninja), StatusCodes.Status201Created)]
        public SwaggerOdata.Entities.Ninja Get([FromODataUri] int key)
        {
            var res = _customNinja.GetById(key);
            return res;
        }


        [ODataRoute("GetByClan")]
        [HttpGet]
        public SwaggerOdata.Entities.Ninja GetByClan([FromODataUri] string clan)
        {
            var res = _customNinja.GetByClan(clan);
            return res;
        }

        [ODataRoute("GetByClanAndName")]
        [HttpGet]
        public SwaggerOdata.Entities.Ninja GetByClanAndName([FromODataUri] string clan, [FromODataUri] string name)
        {
            var res = _customNinja.GetByClanAndName(clan, name);
            return res;
        }

        #region code that will cause malek throwing from a window
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(Entities.Ninja), StatusCodes.Status201Created)]
        //[EnableQuery(MaxExpansionDepth = 5)]
        //[ODataRoute()]

        //public IActionResult GetById([FromODataUri] int id)
        //{
        //    Ninja nin = _ninja.GetById(id);
        //    return Ok(nin);
        //}
        #endregion

        //[ODataRoute("Ninja({Key})")]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(Entities.Ninja), StatusCodes.Status201Created)]
        //public SwaggerOdata.Entities.Ninja Get([FromODataUri] int key)
        //{
        //    var nin = _customNinja.GetById(key);
        //    return nin;
        //}



        //[HttpPatch("{id}")]
        [ODataRoute("Ninja({key})")]
        [ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        public IActionResult Patch([FromODataUri] int key,  Delta<Ninja> updatedNinja)
        {

            var ninja = _ninja.GetById(key);
            try
            {
                updatedNinja.Patch(ninja);
            }
            catch(Exception ex)
            {

            }
            

            _ninja.Update(ninja);
            return Ok(ninja);
         
        }
    }
}
