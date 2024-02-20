using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.Interfaces;

namespace Infrastructure.Dependency
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OnionContext");
    
            service.AddScoped(typeof(IUnitOfWork), u =>
            {
                var context = u.GetService<OnionContext>();
                return new UnitOfWork(context);
            });
            service.AddDbContext<OnionContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return service;
        }
    }
}
