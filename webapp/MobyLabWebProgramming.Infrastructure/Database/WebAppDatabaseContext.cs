﻿using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.Database;

/// <summary>
/// This is the database context used to connect with the database and links the ORM, Entity Framework, with it.
/// </summary>
public sealed class WebAppDatabaseContext : DbContext
{
    public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options, bool migrate = true) : base(options)
    {
        if (migrate)
        {
            Database.Migrate();
        }
    }
    
    // public DbSet<User> Users { get; set; }
    // public DbSet<UserProfile> UserProfiles { get; set; }
    // public DbSet<Application> Applications { get; set; }
    // public DbSet<Organization> Organizations { get; set; }
    // public DbSet<Notification> Notifications { get; set; }

    /// <summary>
    /// Here additional configuration for the ORM is performed.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension("unaccent")
            .ApplyAllConfigurationsFromCurrentAssembly(); // Here all the classes that contain implement IEntityTypeConfiguration<T> are searched at runtime
                                                          // such that each entity that needs to be mapped to the database tables is configured accordingly.
    }
}