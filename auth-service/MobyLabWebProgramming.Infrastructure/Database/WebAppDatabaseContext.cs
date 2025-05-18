using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.Database;

public sealed class WebAppDatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserProfile> UserProfiles { get; set; } = default!;

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