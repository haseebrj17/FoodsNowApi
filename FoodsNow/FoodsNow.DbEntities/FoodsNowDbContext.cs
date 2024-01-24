using System;
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

        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<FranchiseUser> FranchiseUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                "AccountEndpoint=https://byteznowcdb.documents.azure.com:443/;AccountKey=9NHhOaOq21tUSGfjtnyWIItejTUwQ5bI6nPdOuhIwrmFLnmJz3WaRYWKp0CqcsxcrxJVedO4d4t2ACDb3Ueg8A==;",
                databaseName: "BytezNowDB"
        );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperAdmin>().HasKey(e => e.Id);
            modelBuilder.Entity<SuperAdmin>().ToContainer("SuperAdmins").HasPartitionKey(s => s.EmailAddress).HasNoDiscriminator();

            modelBuilder.Entity<FranchiseUser>().HasKey(e => e.Id);
            modelBuilder.Entity<FranchiseUser>().ToContainer("FranchiseUsers").HasPartitionKey(u => u.FranchiseId).HasNoDiscriminator();

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Clients").HasPartitionKey(c => c.EmailAddress).HasNoDiscriminator();

                entity.OwnsMany(c => c.ClientFranchises, franchise =>
                {
                    franchise.WithOwner().HasForeignKey("ClientId");
                    franchise.HasKey("Id");
                });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Countries").HasPartitionKey(c => c.Id).HasNoDiscriminator();

                entity.OwnsMany(c => c.States, state =>
                {
                    state.WithOwner().HasForeignKey("CountryId");
                    state.HasKey("Id");

                    state.OwnsMany(s => s.Cities, city =>
                    {
                        city.WithOwner().HasForeignKey("StateId");
                        city.HasKey("Id");
                    });
                });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Categories");
                entity.HasPartitionKey(c => c.FranchiseId);
                entity.HasNoDiscriminator();

                entity.OwnsMany(c => c.SubCategory, sc =>
                {
                    sc.WithOwner().HasForeignKey("ParentId");
                    sc.HasKey("Id");
                });
            });

            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Franchises");
                entity.HasPartitionKey(f => f.ClientId);
                entity.HasNoDiscriminator();

                entity.OwnsMany(f => f.FranchiseTimings, ft =>
                {
                    ft.WithOwner().HasForeignKey("FranchiseId");
                    ft.HasKey("Id");

                    ft.OwnsMany(t => t.ServingTimings, st =>
                    {
                        st.WithOwner().HasForeignKey("ServingTimingsId");
                        st.HasKey("Id");

                        st.OwnsMany(s => s.ServingTime, time =>
                        {
                            time.WithOwner().HasForeignKey("ServingTimingsId");
                            time.HasKey("Id");
                        });
                    });
                });

                entity.OwnsMany(f => f.FranchiseHolidays, fh =>
                {
                    fh.WithOwner().HasForeignKey("FranchiseId");
                    fh.HasKey("Id");
                });

                entity.OwnsMany(f => f.DishOfDay, dd =>
                {
                    dd.WithOwner().HasForeignKey("FranchiseId");
                    dd.HasKey("Id");
                });

                entity.OwnsMany(f => f.Banner, b =>
                {
                    b.WithOwner().HasForeignKey("FranchiseId");
                    b.HasKey("Id");
                });

                entity.OwnsMany(f => f.Discounts, dis =>
                {
                    dis.WithOwner().HasForeignKey("FranchiseId");
                    dis.HasKey("Id");
                });

                entity.OwnsMany(f => f.FranchiseSetting, fs =>
                {
                    fs.WithOwner().HasForeignKey("FranchiseId");
                    fs.HasKey("Id");
                    fs.OwnsMany(s => s.ServingDays);
                });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Products").HasPartitionKey(p => p.CategoryId).HasNoDiscriminator();

                entity.OwnsMany(p => p.ProductAllergy, allergy =>
                {
                    allergy.WithOwner().HasForeignKey("ProductId");
                    allergy.HasKey("Id");
                });

                entity.OwnsMany(p => p.ProductPrice, price =>
                {
                    price.WithOwner().HasForeignKey("ProductId");
                    price.HasKey("Id");
                });

                entity.OwnsMany(p => p.ProductCategory, category =>
                {
                    category.WithOwner().HasForeignKey("ProductId");
                    category.HasKey("Id");
                });

                entity.OwnsMany(p => p.ProductExtraDipping, dipping =>
                {
                    dipping.WithOwner().HasForeignKey("ProductId");
                    dipping.HasKey("Id");

                    dipping.OwnsMany(d => d.ProductExtraDippingAllergy, allergy =>
                    {
                        allergy.WithOwner().HasForeignKey("DippingId");
                        allergy.HasKey("Id");
                    });
                    dipping.OwnsMany(d => d.ProductExtraDippingPrice, price =>
                    {
                        price.WithOwner().HasForeignKey("DippingId");
                        price.HasKey("Id");
                    });
                });

                entity.OwnsMany(p => p.ProductExtraTopping, topping =>
                {
                    topping.WithOwner().HasForeignKey("ProductId");
                    topping.HasKey("Id");

                    topping.OwnsMany(t => t.ProductExtraToppingAllergy, allergy =>
                    {
                        allergy.WithOwner().HasForeignKey("ToppingId");
                        allergy.HasKey("Id");
                    });
                    topping.OwnsMany(t => t.ProductExtraToppingPrice, price =>
                    {
                        price.WithOwner().HasForeignKey("ToppingId");
                        price.HasKey("Id");
                    });
                });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Orders").HasPartitionKey(p => p.FranchiseId).HasNoDiscriminator();


                entity.OwnsOne(o => o.CustomerDetails, details =>
                {
                    details.WithOwner();
                    details.OwnsOne(d => d.CustomerAddressDetail);
                });

                entity.OwnsMany(o => o.OrderProducts, orderProduct =>
                {
                    orderProduct.WithOwner().HasForeignKey("OrderId");
                    orderProduct.HasKey("Id");
                    orderProduct.OwnsMany(p => p.OrderedProductExtraDipping);
                    orderProduct.OwnsMany(p => p.OrderedProductExtraTopping);
                    orderProduct.OwnsMany(p => p.OrderedProductChoices);
                });

                entity.OwnsOne(o => o.CustomerOrderPromo, promo =>
                {
                    promo.WithOwner();
                });

                entity.OwnsOne(o => o.CustomerOrderPayment, payment =>
                {
                    payment.WithOwner();
                });
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Customers").HasPartitionKey(c => c.CityId).HasNoDiscriminator();

                entity.OwnsMany(c => c.CustomerAddresses, addresses =>
                {
                    addresses.WithOwner().HasForeignKey("CustomerId");
                    addresses.HasKey("Id");
                });

                entity.OwnsOne(c => c.CustomerPayment, payment =>
                {
                    payment.WithOwner();
                });

                entity.OwnsOne(c => c.CustomerPromo, promo =>
                {
                    promo.WithOwner();
                });

                entity.OwnsMany(c => c.CustomerDevice, device =>
                {
                    device.WithOwner().HasForeignKey("CustomerId");
                    device.HasKey("Id");
                });

                entity.OwnsOne(c => c.CustomerPassword, password =>
                {
                    password.WithOwner();
                });
            });

        }
    }
}