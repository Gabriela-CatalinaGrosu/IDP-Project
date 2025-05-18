using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.Database;

public sealed class WebAppDatabaseContext : DbContext
{
    public DbSet<Application> Applications { get; set; } = default!;
    public DbSet<Organization> Organizations { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<Notification> Notifications { get; set; } = default!;

    public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension("unaccent")
            .ApplyAllConfigurationsFromCurrentAssembly();
    }
}