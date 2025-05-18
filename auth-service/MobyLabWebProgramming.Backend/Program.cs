using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Implementations;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core
builder.Services.AddDbContext<WebAppDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebAppDatabase")));

// Add CORS, repository, authorization, and API configurations
builder.AddCorsConfiguration()
    .AddRepository()
    .AddAuthorizationWithSwagger("MobyLab Web App")
    .UseLogger()
    .AddApi();

// Register specific services for auth-service
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

// Add InitializerWorker
builder.Services.AddHostedService<InitializerWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.ConfigureApplication();

app.Run();