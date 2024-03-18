using Autopiter.Application.Services;
using Autopiter.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<HandbookService>();
            services.AddScoped<InstallationService>();



            return services;
        }
    }
}
