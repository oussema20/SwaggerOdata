﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwaggerOdata.Entities;
using SwaggerOdata.Persistence.Context;
using SwaggerOdata.Persistence.Repositories;
using SwaggerOdata.Services;
using SwaggerOdata.Services.Ninja;
using SwaggerOdata.Versionning;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerOdata
{
    public class Startup
    {
        //test malek
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>(Options =>
            {
                Options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<NinjaService, NinjaService>();
            services.AddScoped<IGenericRepository<Ninja>, GenericRepository<Ninja>>();
            services.AddScoped<IGenericService<Ninja>, GenericService<Ninja>>();


            var defaultApiVersion = new ApiVersion(1, 0);

            services.AddApiVersioning(v =>
            {
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = defaultApiVersion;
                v.ReportApiVersions = true;
            });
            services
                .AddOData()
                .EnableApiVersioning();

            services.AddODataApiExplorer(Options =>
            {
                Options.GroupNameFormat = "'v'VVV";
                Options.SubstituteApiVersionInUrl = true;
            });


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                Options =>
                {
                    Options.OperationFilter<SwaggerDefaultValues>();

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, VersionedODataModelBuilder modelBuilder, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
            app.UseMvc(b =>
            {
                b.Select().Expand().OrderBy().MaxTop(100).Count();
                b.MapVersionedODataRoutes("odata", "odata/v{version:apiVersion}", modelBuilder.GetEdmModels());

            });


            app.UseSwagger();
            app.UseSwaggerUI(
             options =>
             {
                 // build a swagger endpoint for each discovered API version
                 foreach (var description in provider.ApiVersionDescriptions)
                 {
                     options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                 }
             });
        }
    }
}
