using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryId(Guid categoryId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public ProductRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            return await _foodsNowDbContext.Products.Join(_foodsNowDbContext.ProductCategories, p => p.Id, c => c.ProductId, (p, c) =>
                new { Products = p, Category = c }).Where(p => p.Category.CategoryId == categoryId).Select(p => p.Products).ToListAsync();
        }
    }
}
