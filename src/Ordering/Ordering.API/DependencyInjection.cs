namespace Ordering.API;

    public static class DependencyInjection
    {
        public static IServiceCollection AddAPInServices(
            this IServiceCollection services)
        {
            services.AddCarter();
		services.AddExceptionHandler<CustomExceptionHandler>();

		return services;
        }

        public static WebApplication UseAPInServices(
            this WebApplication app)
        {
            app.MapCarter();
		app.UseExceptionHandler(options => { });

		return app;
        }
    } 
