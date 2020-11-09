using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using StepCore.Entities;
using StepCore.Framework.Security;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;

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
            services.AddTransient<ICompentenciesRepository, CompentenciesRespository>();
            services.AddTransient<IGenericRepository<Languages>, GenericRepository<Languages>>();
            services.AddTransient<IGenericRepository<Trainings>, GenericRepository<Trainings>>();
            services.AddTransient<IGenericRepository<JobPositions>, GenericRepository<JobPositions>>();
            services.AddTransient<IGenericRepository<LaborExperiences>, GenericRepository<LaborExperiences>>();
            services.AddTransient<IGenericRepository<UserRoles>, GenericRepository<UserRoles>>();
            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IApplicantsRepository, ApplicantsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IJwtAuthenticationManager, JwtAuthenticationManager>();
        }
    }
}
