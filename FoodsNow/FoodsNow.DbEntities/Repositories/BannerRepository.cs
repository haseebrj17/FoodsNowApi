using System;
using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IBannerRepository
    {
        public Task<List<Banner>> GetFranchiseBanners(Guid franchiseId);
    }

    public class BannerRepository : IBannerRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;

        public BannerRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<Banner>> GetFranchiseBanners(Guid franchiseId)
        {
            var franchise = await _foodsNowDbContext.Franchises
                .Include(f => f.Banner)
                .FirstOrDefaultAsync(f => f.Id == franchiseId && f.IsActive);

            return franchise?.Banner.Where(b => b.IsActive).ToList() ?? new List<Banner>();
        }
    }
}

