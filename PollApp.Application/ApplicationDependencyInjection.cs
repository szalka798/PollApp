using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PollApp.Application.MappingProfiles;
using PollApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
        {
            AddServices(services, env);
            RegisterAutoMapper(services);
            return services;
        }
        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<CheckAnswerFactory>();
            services.AddScoped<IPollService, PollService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

    }
}
