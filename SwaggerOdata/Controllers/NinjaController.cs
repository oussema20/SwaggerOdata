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
            _ninja = ninja;
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
        [ODataRoute()]
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
        [ODataRoute()]
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

        [EnableQuery(MaxExpansionDepth = 5)]
        public IActionResult Get([FromODataUri] int key)
        {
            Ninja nin = _ninja.GetById(key);
            return Ok(nin);
        }



        //[HttpPatch("{id}")]
        //[ODataRoute()]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(List<Entities.Ninja>), StatusCodes.Status201Created)]
        //public IActionResult PATCH([FromBody] Ninja obj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        _ninja.Update(obj);
        //        return Ok(obj);
        //    }
        //}
    }
}
