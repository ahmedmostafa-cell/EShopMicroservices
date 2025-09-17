namespace Ordering.API;

public static class DependencyInjection
{
	public static IServiceCollection AddAPInServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddCarter();

		services.AddExceptionHandler<CustomExceptionHandler>();

		services.AddHealthChecks()
			.AddSqlServer(configuration.GetConnectionString("Database")!);

		return services;
	}

	public static WebApplication UseAPInServices(
		this WebApplication app)
	{
		app.MapCarter();
		app.UseExceptionHandler(options => { });

		app.UseHealthChecks("/health",
			new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
			});

		return app;

	}
}
