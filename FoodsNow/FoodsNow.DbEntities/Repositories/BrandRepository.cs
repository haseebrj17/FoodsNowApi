using FoodsNow.DbEntities.Models;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetFranchiseBrands(Guid FranchiseId);
    }
    public class BrandRepository : IBrandRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public BrandRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }
        public List<Brand> GetFranchiseBrands(Guid FranchiseId)
        {
            return _foodsNowDbContext.Brands.Where(b => b.FranchiseId == FranchiseId).ToList();
        }
    }
}
