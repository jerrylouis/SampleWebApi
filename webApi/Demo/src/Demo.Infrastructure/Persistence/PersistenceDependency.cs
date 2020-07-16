using Demo.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence
{
    public static class PersistenceDependency
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<DemoDbContext>(options =>
                options.UseSqlite("Data Source=Demo.db"));

            services.AddScoped<IDemoDbContext>(provider => provider.GetService<DemoDbContext>());

            return services;
        }
    }
}
