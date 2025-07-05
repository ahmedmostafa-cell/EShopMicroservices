using BuildingBlocks.Behaviors;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//Add services to contianier
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));

});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();


builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();
var app = builder.Build();

//Configure http request pipeline
app.MapCarter();

app.Run();
