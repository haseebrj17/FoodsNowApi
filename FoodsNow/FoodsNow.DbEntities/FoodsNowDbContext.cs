using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities
{
    public class FoodsNowDbContext : DbContext
    {
        public FoodsNowDbContext(DbContextOptions<FoodsNowDbContext> options)
            : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<DishOfDay> DishOfDays { get; set; } = null!;
        public DbSet<Franchise> Franchises { get; set; } = null!;
        public DbSet<FranchiseHoliday> FranchiseHolidays { get; set; } = null!;
        public DbSet<FranchiseTiming> FranchiseTimings { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductPrice> ProductPrices { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<ProductExtraTopping> ProductExtraToppings { get; set; } = null!;
        public DbSet<ProductExtraToppingPrice> ProductExtraToppingPrices { get; set; } = null!;
        public DbSet<ProductExtraDipping> ProductExtraDippings { get; set; } = null!;
        public DbSet<ProductExtraDippingPrice> ProductExtraDippingPrices { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<SuperAdmin> SuperAdmins { get; set; } = null!;
        public DbSet<Allergy> Allergies { get; set; } = null!;
        public DbSet<ProductAllergy> ProductAllergies { get; set; } = null!;
        public DbSet<ProductExtraDippingAllergy> ProductExtraDippingAllergies { get; set; } = null!;
        public DbSet<ProductExtraToppingAllergy> ProductExtraToppingAllergies { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerAddress> CustomerAdresses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<OrderProductExtraDipping> OrderProductExtraDippings { get; set; } = null!;
        public DbSet<OrderProductExtraTopping> OrderProductExtraToppings { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>().Property(x => x.Latitude).HasPrecision(18, 7);
            modelBuilder.Entity<Franchise>().Property(x => x.Longitude).HasPrecision(18, 7);
            modelBuilder.Entity<ProductPrice>().Property(x => x.Price).HasPrecision(18, 7);
            modelBuilder.Entity<ProductExtraToppingPrice>().Property(x => x.Price).HasPrecision(18, 7);
            modelBuilder.Entity<ProductExtraDippingPrice>().Property(x => x.Price).HasPrecision(18, 7);
            modelBuilder.Entity<CustomerAddress>().Property(x => x.Latitude).HasPrecision(18, 7);
            modelBuilder.Entity<CustomerAddress>().Property(x => x.Longitude).HasPrecision(18, 7);
            modelBuilder.Entity<Order>().Property(x => x.TotalBill).HasPrecision(18, 7);
            modelBuilder.Entity<OrderProduct>().Property(x => x.UnitPrice).HasPrecision(18, 7);
            modelBuilder.Entity<OrderProductExtraDipping>().Property(x => x.UnitPrice).HasPrecision(18, 7);
            modelBuilder.Entity<OrderProductExtraTopping>().Property(x => x.UnitPrice).HasPrecision(18, 7);

            modelBuilder.Entity<Category>()
            .HasOne(e => e.Franchise)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DishOfDay>()
            .HasOne(e => e.Franchise)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Allergy>()
            .HasOne(e => e.Franchise)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Banner>()
            .HasOne(e => e.Franchise)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
           .HasOne(e => e.Franchise)
           .WithMany()
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
           .HasOne(e => e.CustomerAdress)
           .WithMany()
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
           .HasOne(e => e.ProductPrice)
           .WithMany()
           .OnDelete(DeleteBehavior.Restrict);
        }
    }


}