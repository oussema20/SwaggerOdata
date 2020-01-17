using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using SwaggerOdata.Entities;
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
            var function = builder.Function("GetByClan").ReturnsCollectionFromEntitySet<Ninja>("Ninja");
            function.Parameter<string>("clan");

            var function2 = builder.Function("GetByClanAndName").ReturnsCollectionFromEntitySet<Ninja>("Ninja");
            function2.Parameter<string>("clan");
            function2.Parameter<string>("name");
        }

    }
}
