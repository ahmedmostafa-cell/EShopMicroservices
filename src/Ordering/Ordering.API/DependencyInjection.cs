namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPInServices(
            this IServiceCollection services)
        {
            //services.AddCarter();

            return services;
        }

        public static WebApplication UseAPInServices(
            this WebApplication app)
        {
            //app.MapCarter();
            return app;
        }
    } 
}
