using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICityRepository
    {
        public Task<Guid?> GetCityIdByName(string cityName, string stateName, string countryName);
        public Task<Guid> AddCity(string cityName, string stateName, string countryName);
        Task<CityName?> GetCityById(Guid cityId);

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
            var country = await _foodsNowDbContext.Country
                           .Include(c => c.States)
                               .ThenInclude(s => s.Cities)
                           .FirstOrDefaultAsync(c => c.Name.ToLower() == countryName.ToLower())
                       ?? new Country { Name = countryName };

            if (country.Id == Guid.Empty)
            {
                _foodsNowDbContext.Country.Add(country);
            }

            var state = country.States.FirstOrDefault(s => s.Name.ToLower() == stateName.ToLower())
                       ?? new State { Name = stateName };

            if (state.Id == Guid.Empty)
            {
                country.States.Add(state);
            }

            var city = state.Cities.FirstOrDefault(c => c.Name.ToLower() == cityName.ToLower())
                      ?? new CityName { Name = cityName };

            if (city.Id == Guid.Empty)
            {
                state.Cities.Add(city);
            }

            await _foodsNowDbContext.SaveChangesAsync();
            return city.Id;
        }

        public async Task<Guid?> GetCityIdByName(string cityName, string stateName, string countryName)
        {
            var countriesData = await _foodsNowDbContext.Country
                .Include(c => c.States)
                    .ThenInclude(state => state.Cities)
                .FirstOrDefaultAsync(c => c.Name.ToLower() == countryName.ToLower());

            var state = countriesData?.States.FirstOrDefault(s => s.Name.ToLower() == stateName.ToLower());
            var city = state?.Cities.FirstOrDefault(c => c.Name.ToLower() == cityName.ToLower());

            return city?.Id;
        }

        public async Task<CityName?> GetCityById(Guid cityId)
        {
            var city = await _foodsNowDbContext.Country
                        .Include(c => c.States)
                                .ThenInclude(state => state.Cities)
                            .SelectMany(country => country.States)
                                .SelectMany(state => state.Cities)
                        .FirstOrDefaultAsync(city => city.Id == cityId);

            return city;
        }
    }
}