using FoodsNow.DbEntities.Models;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetFranchiseBrands(Guid FranchiseId);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CategoryRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }
        public List<Category> GetFranchiseBrands(Guid FranchiseId)
        {
            return _foodsNowDbContext.Categories.Where(b => b.FranchiseId == FranchiseId && b.IsActive && b.IsVisibleOnDashboard).ToList();
        }
    }
}
