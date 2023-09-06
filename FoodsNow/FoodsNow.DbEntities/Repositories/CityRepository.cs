namespace FoodsNow.DbEntities.Repositories
{
    public interface ICityRepository
    {
        public Guid? GetCityIdByName(string name);
    }
    public class CityRepository : ICityRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CityRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public Guid? GetCityIdByName(string name)
        {
            return _foodsNowDbContext.Cities.FirstOrDefault(c => c.Name.ToLower() == name.ToLower())?.Id;
        }
    }
}
