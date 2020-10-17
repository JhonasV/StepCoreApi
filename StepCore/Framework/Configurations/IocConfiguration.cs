using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Framework.Configurations
{
    public static class IocConfiguration
    {
        public static void Init(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<StepCoreContext, StepCoreContext>();

            services.Scan(x => x.FromAssemblyOf<StepCoreContext>()
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime());

            // Dependecies Injection
            services.AddTransient<IGenericRepository<Compentencies>, GenericRepository<Compentencies>>();
            services.AddTransient<IGenericRepository<Languages>, GenericRepository<Languages>>();
            services.AddTransient<IGenericRepository<Trainings>, GenericRepository<Trainings>>();
            services.AddTransient<IGenericRepository<JobPositions>, GenericRepository<JobPositions>>();
            services.AddTransient<IGenericRepository<Applicants>, GenericRepository<Applicants>>();
            services.AddTransient<IGenericRepository<LaborExperiences>, GenericRepository<LaborExperiences>>();
            services.AddTransient<IApplicantsRepository, ApplicantsRepository>();
        }
    }
}
