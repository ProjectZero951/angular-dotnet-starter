using Starter.Application;
using Starter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
