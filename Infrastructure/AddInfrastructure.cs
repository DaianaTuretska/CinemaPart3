using Application.Interfaces;
using Infrastructure.Contexts.EntityFrameworkDbContext;
using Infrastructure.Contexts.MongoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectingString = configuration.GetConnectionString("MSSQLConnectionTest");
            services.AddDbContext<ApplicationDbContext>(config =>
                config.UseSqlServer(connectingString));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
           return services;
        }
    }
}
