using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IProductExtraToppingRepository
    {
        Task<List<ProductExtraTopping>> GetProductExtraToppings();
    }
    public class ProductExtraToppingRepository : IProductExtraToppingRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public ProductExtraToppingRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<ProductExtraTopping>> GetProductExtraToppings()
        {
            return await _foodsNowDbContext.ProductExtraToppings.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy).ToListAsync();
        }
    }
}
