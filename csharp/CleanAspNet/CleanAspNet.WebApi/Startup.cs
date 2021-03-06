using CleanAspNet.Data;
using CleanAspNet.Domain.UseCases.SendGreeting;
using CleanAspNetWebApi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAspNetWebApi
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
            // Factory for UseCases is needed to solve circular dependency error:
            // Error while validating the service descriptor 'ServiceType: CleanAspNet.Domain.UseCases.Greeting.IGetGreetingPresenter Lifetime: Scoped ImplementationType: CleanAspNetWebApi.Controllers.GetGreetingController':
            // A circular dependency was detected for the service of type 'CleanAspNet.Domain.UseCases.Greeting.IGetGreetingPresenter'.
            // CleanAspNet.Domain.UseCases.Greeting.IGetGreetingPresenter(CleanAspNetWebApi.Controllers.GetGreetingController)->CleanAspNet.Domain.UseCases.Greeting.GetGreetingHandler->CleanAspNet.Domain.UseCases.Greeting.IGetGreetingPresenter
            // Solution from https://stackoverflow.com/a/41072001/1451757,
            // also https://medium.com/software-ascending/circular-dependencies-in-dependency-injection-403b790daebb
            //      => "circular dependencies in software are solvable because the dependencies are always self-imposed by the developers"
            services.AddScoped<UseCasesFactory>();

            services.AddScoped<ISendGreetingPresenter, SendGreetingController>();
            services.AddScoped<ISendGreetingRepository, SendGreetingReposiory>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanAspNetWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanAspNetWebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
