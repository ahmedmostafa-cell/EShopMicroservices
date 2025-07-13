namespace Discount.Grpc.Data;

public static class Extension
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app) 
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            try 
            {
                dbContext.Database.Migrate();

            }
            catch(Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<DiscountContext>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }

        return app;
    }
}
