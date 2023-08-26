namespace FoodsNow.DbEntities.Repositories
{
    public interface ICustomerRepository
    {

    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CustomerRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

    }
}
