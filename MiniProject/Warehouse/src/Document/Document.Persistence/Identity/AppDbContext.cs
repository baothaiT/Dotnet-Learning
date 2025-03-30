using Document.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Document.Persistence.Identity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<DocumentEntity> DocumentTable { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DocumentEntity>()
           .HasKey(x => new { x.Id });

        modelBuilder = SeedingData(modelBuilder);
    }

    private ModelBuilder SeedingData(ModelBuilder modelBuilder)
    {
        //Seeding Proxy
        #region ProxyTable
        Guid documnetId1 = Guid.NewGuid();

        DocumentEntity documentEntity = new DocumentEntity()
        {
            Id = documnetId1,
            Code = "Code",
        };

        modelBuilder.Entity<DocumentEntity>().HasData(
            documentEntity
        );
        #endregion
        return modelBuilder;
    }
}
