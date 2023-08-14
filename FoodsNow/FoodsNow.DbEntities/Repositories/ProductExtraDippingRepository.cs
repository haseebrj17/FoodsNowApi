﻿using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IProductExtraDippingRepository
    {
        Task<List<ProductExtraDipping>> GetProductExtraDippings();
    }
    public class ProductExtraDippingRepository : IProductExtraDippingRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public ProductExtraDippingRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<ProductExtraDipping>> GetProductExtraDippings()
        {
            return await _foodsNowDbContext.ProductExtraDippings.Include(p => p.Prices).Include(p => p.Allergies).ThenInclude(a => a.Allergy).ToListAsync();
        }
    }
}