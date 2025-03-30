

//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.EntityFrameworkCore;
//using User.Domain.Entities;

//namespace User.Persistence.Identity;

//public class AppDbContext : DbContext
//{
//    public AppDbContext(DbContextOptions<AppDbContext> options)
//        : base(options)
//    {
//    }

//    public DbSet<DocummentEntity> ProductsTable { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<ProductEntity>()
//           .HasKey(x => new { x.Id });

//        // modelBuilder = SeedingData(modelBuilder);
//    }

//    private ModelBuilder SeedingData(ModelBuilder modelBuilder)
//    {
//        //Seeding Proxy
//        #region ProxyTable
//        Guid productId1 = Guid.NewGuid();

//        ProductEntity productEntity = new ProductEntity()
//        {
//            Id = productId1,
//            Name = "Name",
//            Price = 1,
//            Stock = 1
//        };

//        modelBuilder.Entity<ProductEntity>().HasData(
//            productEntity
//        );
//        #endregion
//        return modelBuilder;
//    }
//}

