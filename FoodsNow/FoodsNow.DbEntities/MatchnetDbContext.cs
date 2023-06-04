using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities
{
    public class FoodsNowDbContext : DbContext
    {
        public FoodsNowDbContext(DbContextOptions<FoodsNowDbContext> options)
            : base(options)
        {
        }
    }
}