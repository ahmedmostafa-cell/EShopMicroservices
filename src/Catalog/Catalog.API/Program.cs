var builder = WebApplication.CreateBuilder(args);

//Add services to contianier

var app = builder.Build();

//Configure http request pipeline


app.Run();
