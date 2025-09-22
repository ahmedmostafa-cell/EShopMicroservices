var builder = WebApplication.CreateBuilder(args);
builder.Services
		 .AddApplicationServices(builder.Configuration)
		 .AddInfrastructure(builder.Configuration)
		 .AddAPInServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAPInServices();
if (app.Environment.IsDevelopment())
{
	await app.InitializeDatabaseAsync();
}
app.MapGet("/", () => "Hello World!");

app.Run();
