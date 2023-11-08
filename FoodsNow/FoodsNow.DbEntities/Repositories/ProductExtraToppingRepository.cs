using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IProductExtraToppingRepository
    {
        Task<List<ProductExtraTopping>> GetProductExtraToppings();
        Task<ProductExtraTopping> GetProductExtraToppingById(Guid productExtraToppingId);
    }
    public class ProductExtraToppingRepository : IProductExtraToppingRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public ProductExtraToppingRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<ProductExtraTopping> GetProductExtraToppingById(Guid productExtraToppingId)
        {
            return await _foodsNowDbContext.ProductExtraToppings.Include(p => p.Prices).Include(p => p.Allergies)
                .ThenInclude(a => a.Allergy).FirstOrDefaultAsync(p => p.Id == productExtraToppingId);
        }

        public async Task<List<ProductExtraTopping>> GetProductExtraToppings()
        {
            return await _foodsNowDbContext.ProductExtraToppings.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy).ToListAsync();
        }
    }
}
