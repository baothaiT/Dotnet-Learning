using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Set string key column size explicitly for SQL Server compatibility
        builder.Entity<IdentityRole>(b =>
        {
            b.Property(r => r.Id).HasMaxLength(450);
            b.Property(r => r.NormalizedName).HasMaxLength(256);
        });

        builder.Entity<IdentityUser>(b =>
        {
            b.Property(u => u.Id).HasMaxLength(450);
            b.Property(u => u.NormalizedUserName).HasMaxLength(256);
            b.Property(u => u.NormalizedEmail).HasMaxLength(256);
        });
    }
}
