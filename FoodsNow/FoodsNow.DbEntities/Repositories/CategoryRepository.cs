using FoodsNow.DbEntities.Models;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetFranchiseBrands(Guid franchiseId);
        List<Category> GetChildCategories(Guid categoryId);
        List<Category> GetCategories(Guid franchiseId);
        Category? GetCategoryByName(string name);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CategoryRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public List<Category> GetChildCategories(Guid categoryId)
        {
            return _foodsNowDbContext.Categories.Where(b => b.ParentId == categoryId && b.IsActive).OrderBy(c => c.Sequence).ToList();
        }

        public List<Category> GetFranchiseBrands(Guid franchiseId)
        {
            return _foodsNowDbContext.Categories.Where(b => b.FranchiseId == franchiseId && b.IsActive && b.IsBrand).OrderBy(c => c.Sequence).ToList();
        }

        public List<Category> GetCategories(Guid franchiseId)
        {
            return _foodsNowDbContext.Categories.Where(b => b.FranchiseId == franchiseId && b.IsActive && !b.IsBrand && b.ParentId == null).OrderBy(c => c.Sequence).ToList();
        }

        public Category? GetCategoryByName(string name)
        {
            return _foodsNowDbContext.Categories.FirstOrDefault(c => c.Name == name && c.IsActive);
        }
    }
}
