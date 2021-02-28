using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;
using IngaiaService02.Api.Infra.Services;
using IngaiaService02.Domain;

namespace IngaiaService02.Api
{
    public class Startup
    {

        private  PropertyCategorySettings propertyCategorySettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            propertyCategorySettings = configuration.GetSection("Api").Get<PropertyCategorySettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(typeof(PropertyCategorySettings), propertyCategorySettings);
            services.AddScoped<IPropertyCategoryService, PropertyCategoryService>();
            services.AddScoped<ICalculatePropertyValue, CalculatePropertyValue>();

            services.AddSwaggerGen(x =>
           {
               x.SwaggerDoc("v1", new OpenApiInfo { Title = "External API", Version = "v1" });
               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               if (File.Exists(xmlPath))
                   x.IncludeXmlComments(xmlPath);

               x.EnableAnnotations();
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ingaia Teste");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
