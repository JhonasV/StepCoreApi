using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Framework.Configurations
{
    public static class AuthConfiguration
    {
        public static void Init(IConfiguration configuration, IServiceCollection services)
        {
            services.AddAuthentication();
        }
    }
}
