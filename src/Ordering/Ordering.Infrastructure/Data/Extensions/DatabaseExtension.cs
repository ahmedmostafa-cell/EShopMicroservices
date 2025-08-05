namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtension
{
	public static async Task InitializeDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		context.Database.MigrateAsync().GetAwaiter().GetResult();
		await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context) 
	{
		await SeedCustomerAync(context);
        await SeedProductAync(context);
        await SeedOrderAndItemsAync(context);
    }

    private static async Task SeedCustomerAync(ApplicationDbContext context) 
	{
		if (!await context.Customers.AnyAsync()) 
		{
            await context.Customers.AddRangeAsync(InitialData.Customers);
			await context.SaveChangesAsync();
		}
	}

    private static async Task SeedProductAync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOrderAndItemsAync(ApplicationDbContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
            await context.SaveChangesAsync();
        }
    }
}
