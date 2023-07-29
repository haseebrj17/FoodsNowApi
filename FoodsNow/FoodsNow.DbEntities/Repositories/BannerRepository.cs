using FoodsNow.DbEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IBannerRepository
    {
        List<Banner> GetFranchiseBanners(Guid FranchiseId);
    }

    public class BannerRepository : IBannerRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public BannerRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }
        public List<Banner> GetFranchiseBanners(Guid FranchiseId)
        {
            return _foodsNowDbContext.Banners.Where(b => b.FranchiseId == FranchiseId).ToList();
        }
    }
}
