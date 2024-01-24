using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetFranchiseBrands(Guid franchiseId);
        List<SubCategory> GetChildCategories(Guid categoryId);
        Task<List<SubCategory>> GetAllSubCategories(Guid franchiseId);
        List<Category> GetFranchiseCategories(Guid franchiseId);
        Category? GetCategoryByName(string name);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CategoryRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public List<SubCategory> GetChildCategories(Guid categoryId)
        {
            var parentCategory = _foodsNowDbContext.Categories
                .Include(c => c.SubCategory)
                .FirstOrDefault(c => c.Id == categoryId && c.IsActive);

            return parentCategory?.SubCategory.Where(b => b.IsActive).OrderBy(c => c.Sequence).ToList() ?? new List<SubCategory>();
        }

        public List<Category> GetFranchiseBrands(Guid franchiseId)
        {
            return _foodsNowDbContext.Categories.Where(b => b.FranchiseId == franchiseId && b.IsActive && b.IsBrand).OrderBy(c => c.Sequence).ToList();
        }

        public async Task<List<SubCategory>> GetAllSubCategories(Guid franchiseId)
        {
            var categories = await _foodsNowDbContext.Categories
                .Include(c => c.SubCategory)
                .Where(c => c.FranchiseId == franchiseId && c.IsActive)
                .OrderBy(c => c.Sequence)
                .ToListAsync();

            var allSubCategories = new List<SubCategory>();
            foreach (var category in categories)
            {
                allSubCategories.AddRange(category.SubCategory
                    .Where(sc => sc.IsActive)
                    .OrderBy(sc => sc.Sequence));
            }

            return allSubCategories;
        }

        public List<Category> GetFranchiseCategories(Guid franchiseId)
        {
            return _foodsNowDbContext.Categories.Where(c => c.FranchiseId == franchiseId && c.IsBrand == false).OrderBy(c => c.Sequence).ToList();
        }

        public Category? GetCategoryByName(string name)
        {
            return _foodsNowDbContext.Categories.FirstOrDefault(c => c.Name == name && c.IsActive);
        }
    }
}