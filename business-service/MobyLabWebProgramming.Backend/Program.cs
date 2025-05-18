using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Implementations;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure HttpClient for db-service
builder.Services.AddHttpClient<IDbServiceClient, DbServiceClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["DbServiceUrl"]);
});

// Add CORS, API, and services
builder.AddCorsConfiguration()
    .AddApi()
    .UseLogger();

// Register services
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

app.ConfigureApplication();

app.Run();