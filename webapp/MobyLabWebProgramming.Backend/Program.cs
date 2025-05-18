using MobyLabWebProgramming.Infrastructure.Extensions;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Adaugă OpenTelemetry pentru tracing cu Jaeger
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService("MobyLabWebProgramming"))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddJaegerExporter(o =>
        {
            o.AgentHost = "jaeger";
            o.AgentPort = 6831;
        }));

// Adaugă HealthChecks pentru Prometheus
builder.Services.AddHealthChecks();

// Configurează serviciile existente
builder.AddCorsConfiguration()
    .AddRepository()
    .AddAuthorizationWithSwagger("MobyLab Web App")
    .AddServices()
    .UseLogger()
    .AddWorkers()
    .AddApi();

var app = builder.Build();

// Configurează middleware
app.UseHttpMetrics(); // Colectează metrici HTTP pentru Prometheus
app.UseHealthChecks("/health");
app.MapMetrics("/metrics"); // Expu metricile pentru Prometheus

// Configurează aplicația cu middleware-urile existente
app.ConfigureApplication();

app.Run();