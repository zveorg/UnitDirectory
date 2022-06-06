using UnitDirectory.Application.Extensions;
using UnitDirectory.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services
    .AddApplication()
    .AddInfrastucture(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure();

app.MapRazorPages();

app.Run();
