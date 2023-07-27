using AutoMapper;
using ICare.Business.Business;
using ICare.Mapper;
using ICare.Repository.Repository.Common;
using ICare.Repository.Repository.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Icare API",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Icare",
                        Email = string.Empty,
                    }
                });
            });
            
            services.AddImplementationMethods();
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new AutoMapperProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(options =>
            {
                // requires using Microsoft.AspNetCore.Mvc.Formatters;
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });
            //services.AddControllers().AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin()
                                           .AllowAnyMethod()
                                           .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            

            app.UseAuthorization();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui(HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Icare Versioned API v1.0");
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "Title Documentation";
                options.DocExpansion(DocExpansion.List);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
