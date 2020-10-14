using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;

namespace StepCore
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
            string connString = Configuration.GetConnectionString("StepCoreSqlServerConnString");
            services.AddDbContext<StepCoreContext>(option => option.UseSqlServer(connString));

            // Dependecies Injection
            services.AddTransient<IGenericRepository<Compentencies>, GenericRepository<Compentencies>>();
            services.AddTransient<IGenericRepository<Languages>, GenericRepository<Languages>>();
            services.AddTransient<IGenericRepository<Trainings>, GenericRepository<Trainings>>();
            services.AddTransient<IGenericRepository<JobPositions>, GenericRepository<JobPositions>>();
            services.AddTransient<IGenericRepository<Applicants>, GenericRepository<Applicants>>();
            services.AddTransient<IGenericRepository<LaborExperiences>, GenericRepository<LaborExperiences>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler(app => app.Run(async context => {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
