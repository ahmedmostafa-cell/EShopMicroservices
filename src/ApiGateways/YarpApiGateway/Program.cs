var builder = WebApplication.CreateBuilder(args);

// Add services to the container

var app = builder.Build();

// Configure HTTP request for pipeline

app.Run();
