using FoodsNow.DbEntities.Models;
using System.Data.Entity;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IFranchiseRepository
    {
        Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude);
    }
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public FranchiseRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude)
        {
            //Todo: get by lati longi
            return await _foodsNowDbContext.Franchises.FirstAsync();//.FindAsync(latidude, longitude);
        }
    }
}
