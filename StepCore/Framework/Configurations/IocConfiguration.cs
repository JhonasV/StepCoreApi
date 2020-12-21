﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using StepCore.Data.Models;
using StepCore.Entities;
using StepCore.Framework.Models;
using StepCore.Framework.Security;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;
using System;

namespace StepCore.Framework.Configurations
{
    public static class IocConfiguration
    {
        public static void Init(IConfiguration configuration, IServiceCollection services)
        {
            var seedConfig = configuration.GetSection(nameof(SeedConfig)).Get<SeedConfig>();

            if (seedConfig == null)
            {
                throw new Exception($"The configuration for {nameof(SeedConfig)} was no supply");
            }

            services.AddSingleton(seedConfig);


            // Dependecies Injection
            services.AddScoped<StepCoreContext, StepCoreContext>();
            services.AddTransient<ICompentenciesRepository, CompentenciesRespository>();
            services.AddTransient<IGenericRepository<Languages>, GenericRepository<Languages>>();
            services.AddTransient<IGenericRepository<Trainings>, GenericRepository<Trainings>>();
            services.AddTransient<IGenericRepository<JobPositions>, GenericRepository<JobPositions>>();
            services.AddTransient<ILaborExperiencesRepository,LaborExperiencesRepository>();
            services.AddTransient<IGenericRepository<UserRoles>, GenericRepository<UserRoles>>();
            services.AddTransient<IGenericRepository<Employees>, GenericRepository<Employees>>();
            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IApplicantsRepository, ApplicantsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IJwtAuthenticationManager, JwtAuthenticationManager>();
        }
    }
}
