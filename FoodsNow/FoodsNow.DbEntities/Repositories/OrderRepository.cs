namespace FoodsNow.DbEntities.Repositories
{
    public interface IOrderRepository
    {

    }
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public OrderRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }
       
    }
}
