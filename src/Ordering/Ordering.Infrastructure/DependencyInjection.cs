using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        //services.AddDbContext<OrderingContext>(options =>
        //    options.UseSqlServer(connectionString));

        //services.AddScoped<IApplicationContext, ApplicationContext>();

        return services;
    }
}
