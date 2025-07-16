using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);



builder.Services
         .AddAPInServices()
         .AddInfrastructure(builder.Configuration)
         .AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAPInServices();

app.MapGet("/", () => "Hello World!");

app.Run();
