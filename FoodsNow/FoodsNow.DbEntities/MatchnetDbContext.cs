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
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<DishOfDay> DishOfDays { get; set; } = null!;
        public DbSet<Franchise> Franchises { get; set; } = null!;
        public DbSet<FranchiseHoliday> FranchiseHolidays { get; set; } = null!;
        public DbSet<FranchiseTiming> FranchiseTimings { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<ProductExtraTopping> ProductExtraToppings { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<SuperAdmin> SuperAdmins { get; set; } = null!;
    }
}