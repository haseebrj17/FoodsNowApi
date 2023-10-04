using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICityRepository
    {
        public Guid? GetCityIdByName(string name);
        public Task<Guid> AddCity(string cityName, string stateName, string countryName);
    }
    public class CityRepository : ICityRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CityRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<Guid> AddCity(string cityName, string stateName, string countryName)
        {
            var country = await _foodsNowDbContext.Countries.FirstOrDefaultAsync(c => c.Name.ToLower() == countryName.ToLower());

            if (country == null)
            {
                country = new Country() { Name = countryName, CreatedById = Guid.NewGuid(), CreatedDateTimeUtc = DateTime.UtcNow };

                await _foodsNowDbContext.Countries.AddAsync(country);

                await _foodsNowDbContext.SaveChangesAsync();
            }

            var state = await _foodsNowDbContext.States.FirstOrDefaultAsync(c => c.Name.ToLower() == stateName.ToLower());

            if (state == null)
            {
                state = new State() { Name = stateName, CreatedById = Guid.NewGuid(), CreatedDateTimeUtc = DateTime.UtcNow, CountryId = country.Id, Country = country };

                await _foodsNowDbContext.States.AddAsync(state);

                await _foodsNowDbContext.SaveChangesAsync();
            }

            var city = new City() { Name = cityName, CreatedById = Guid.NewGuid(), CreatedDateTimeUtc = DateTime.UtcNow, StateId = state.Id, State = state };

            await _foodsNowDbContext.Cities.AddAsync(city);

            await _foodsNowDbContext.SaveChangesAsync();

            return city.Id;
        }

        public Guid? GetCityIdByName(string name)
        {
            return _foodsNowDbContext.Cities.FirstOrDefault(c => c.Name.ToLower() == name.ToLower())?.Id;
        }
    }
}
