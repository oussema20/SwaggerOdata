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
    [ODataRoutePrefix("User")]
    public class UserController : ODataController
    {
        private IGenericService<User> _user;


        public UserController(IGenericService<SwaggerOdata.Entities.User> user)
        {
            _user = user;
        }
        //[HttpGet]
        [ODataRoute()]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Entities.User>), StatusCodes.Status201Created)]
        public async Task<IEnumerable<SwaggerOdata.Entities.User>> GetAll()
        {
            var result = await _user.GetAll();
            return result;
        }
    }
}
