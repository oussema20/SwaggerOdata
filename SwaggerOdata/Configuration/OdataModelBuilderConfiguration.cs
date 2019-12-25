using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Configuration
{
    public class OdataModelBuilderConfiguration : IModelConfiguration

    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Entities.Ninja>("Ninja");
            builder.EntitySet<Entities.User>("User");
            var function = builder.Function("GetById").ReturnsFromEntitySet<Entities.Ninja>("GetById");
            function.Parameter<int>("id");
        }

    }
}
