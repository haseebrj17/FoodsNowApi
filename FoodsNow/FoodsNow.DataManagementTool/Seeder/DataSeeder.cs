using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FoodsNow.DbEntities;
using FoodsNow.DbEntities.Models;

namespace FoodsNow.DataManagementTool.Seeder
{
    public class DataSeeder
    {
        private readonly FoodsNowDbContext _context;

        public DataSeeder(FoodsNowDbContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            await SeedAdminAsync();
            await SeedCountryAsync();
            await SeedClientAsync();
            await SeedFranchisesAsync();
            await SeedFranchisesUserAsync();
            await SeedCategoriesAsync();
            await SeedProductsAsync();
        }

        private async Task SeedFranchisesAsync()
        {
            var franchisesExist = await _context.Franchises.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!franchisesExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/Franchise.json");
                var franchises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Franchise>>(jsonData);
                if (franchises != null)
                {
                    _context.Franchises.AddRange(franchises);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedClientAsync()
        {
            var cleintExist = await _context.Clients.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!cleintExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/ClientJson.json");
                var cleint = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Client>>(jsonData);
                if (cleint != null)
                {
                    _context.Clients.AddRange(cleint);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedAdminAsync()
        {
            var AdminExist = await _context.SuperAdmins.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!AdminExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/AdminJson.json");
                var admin = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SuperAdmin>>(jsonData);
                if (admin != null)
                {
                    _context.SuperAdmins.AddRange(admin);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedCountryAsync()
        {
            var countryExist = await _context.Country.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!countryExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/CountryJson.json");
                var country = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(jsonData);
                if (country != null)
                {
                    _context.Country.AddRange(country);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedFranchisesUserAsync()
        {
            var franchisesUserExist = await _context.FranchiseUsers.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!franchisesUserExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/FranchiseUser.json");
                var franchisesUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FranchiseUser>>(jsonData);
                if (franchisesUser != null)
                {
                    _context.FranchiseUsers.AddRange(franchisesUser);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedCategoriesAsync()
        {
            var CategoriesExist = await _context.Categories.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!CategoriesExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/Categories.json");
                var categories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(jsonData);
                if (categories != null)
                {
                    _context.Categories.AddRange(categories);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedProductsAsync()
        {
            var ProductsExist = await _context.Products.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!ProductsExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/Products.json");
                var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);
                if (products != null)
                {
                    _context.Products.AddRange(products);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}