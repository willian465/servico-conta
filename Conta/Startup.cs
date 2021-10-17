using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conta.Extensions.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Conta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()));

            // registro das dependências
            services.RegistrarDependencias(_configuration);
            
            // usei o cache para simular a base de dados
            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Conta", Version = "v1" });
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new QueryStringApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UseSwagger(app, "");
        }
        private void UseSwagger(IApplicationBuilder app, string routerPrefix)
        {
            app.UseSwagger(
                c => c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    //s.Paths = routerPrefix;
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{routerPrefix}" },
                                                                   new OpenApiServer { Url = $"https://{httpReq.Host.Value}{routerPrefix}" }
                                                                 };

                }));
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{routerPrefix}/swagger/v1/swagger.json", $"{_configuration.GetSection("Application").GetValue<string>("EndpointName")}");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
