using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IFranchiseRepository
    {
        Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude);
        Task<List<Franchise>> GetClientFranchises(Guid clientId);
    }
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public FranchiseRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<Franchise>> GetClientFranchises(Guid clientId)
        {
            return await _foodsNowDbContext.Franchises.Where(f => f.ClientId == clientId && f.IsActive).ToListAsync();
        }

        public async Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude)
        {
            //Todo: get by lati longi
            return await _foodsNowDbContext.Franchises.FirstAsync();//.FindAsync(latidude, longitude);
        }
    }
}
