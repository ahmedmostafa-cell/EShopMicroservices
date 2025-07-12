namespace Discount.Grpc.Data;

public static class Extension
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app) 
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dbContext.Database.Migrate();
        }

        return app;
    }
}
