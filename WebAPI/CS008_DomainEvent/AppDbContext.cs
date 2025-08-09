using System;
using CS004_SwaggerUI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS004_SwaggerUI;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure BaseEntity
        modelBuilder.Entity<UserEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Seed data for UserEntity
        var seedUsers = new[]
        {
            new
            {
                Id = "user-001",
                Username = "john_doe",
                Email = "john.doe@example.com",
                PasswordHash = "hashedpassword123", // In real apps, use proper hashing
                Status = Status.Active,
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = "user-002",
                Username = "jane_smith",
                Email = "jane.smith@example.com",
                PasswordHash = "hashedpassword456",
                Status = Status.Active,
                CreatedAt = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = "user-003",
                Username = "bob_wilson",
                Email = "bob.wilson@example.com",
                PasswordHash = "hashedpassword789",
                Status = Status.New,
                CreatedAt = new DateTime(2024, 1, 3, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = "user-004",
                Username = "alice_brown",
                Email = "alice.brown@example.com",
                PasswordHash = "hashedpassword101",
                Status = Status.Inactive,
                CreatedAt = new DateTime(2024, 1, 4, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = "user-005",
                Username = "charlie_davis",
                Email = "charlie.davis@example.com",
                PasswordHash = "hashedpassword102",
                Status = Status.Active,
                CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc)
            }
        };

        modelBuilder.Entity<UserEntity>().HasData(seedUsers);
    }
}
