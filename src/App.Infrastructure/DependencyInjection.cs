using System.Reflection;
using App.Infrastructure.EfDriver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
            });
        });
        return services;
    }
}
