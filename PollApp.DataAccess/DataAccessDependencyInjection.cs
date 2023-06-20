using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PollApp.DataAccess.Identity;
using PollApp.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDatabase(configuration);
            services.AddIdentity();


            return services;
        }
        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=PollApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DatabaseContext>();
        }


    }
}
