using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryId(Guid categoryId);
        Task<List<Product>> GetProductsByCategoryIds(List<Guid> categoryIds);
        Task<List<Product>> GetProductsById(List<Guid> productIds);
        Task<Product> GetProductById(Guid productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public ProductRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<Product>> GetProductsById(List<Guid> productIds)
        {
            var products = await _foodsNowDbContext.Products.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy)
                    .Where(p => productIds.Contains(p.Id) && p.IsActive).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            var products = await _foodsNowDbContext.Products.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy)
                    .Join(_foodsNowDbContext.ProductCategories,
                p => p.Id, c => c.ProductId, (p, c) =>
                    new { Products = p, Category = c }).Where(p => p.Category.CategoryId == categoryId && p.Products.IsActive).Select(p => p.Products).OrderBy(p => p.Sequence).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryIds(List<Guid> categoryIds)
        {
            var products = await _foodsNowDbContext.Products.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy)
                    .Include(p => p.ProductCategories).Where(p => p.ProductCategories.Where(c => categoryIds.Contains(c.CategoryId)).Any()).ToListAsync();

            return products;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await _foodsNowDbContext.Products.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy)
                    .Where(p => p.Id == productId && p.IsActive).OrderBy(p => p.Sequence).FirstAsync();
            return product;
        }
    }
}
