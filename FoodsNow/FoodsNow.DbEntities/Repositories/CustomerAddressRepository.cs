using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICustomerAddressRepository
    {
        Task<CustomerAddress?> AddAddress(CustomerAddress customer);
        Task<bool> UpdateAddress(CustomerAddress customer);
        Task<List<CustomerAddress>> GetAllAddresses(Guid customerId);
    }
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CustomerAddressRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<CustomerAddress?> AddAddress(CustomerAddress customerAddress)
        {
            if (customerAddress == null)
                return null;

            if (await _foodsNowDbContext.CustomerAdresses.AnyAsync(c => c.StreetAddress == customerAddress.StreetAddress && c.House == customerAddress.House
                    && c.CityId == customerAddress.CityId && c.CustomerId == customerAddress.CustomerId))
                return null;

            customerAddress.CreatedDateTimeUtc = DateTime.UtcNow;
            customerAddress.UpdatedDateTimeUtc = DateTime.UtcNow;
            customerAddress.CreatedById = customerAddress.CustomerId;
            customerAddress.UpdatedById = customerAddress.CustomerId;

            await _foodsNowDbContext.CustomerAdresses.AddAsync(customerAddress);

            await _foodsNowDbContext.SaveChangesAsync();

            return customerAddress;
        }

        public async Task<List<CustomerAddress>> GetAllAddresses(Guid customerId)
        {
            return await _foodsNowDbContext.CustomerAdresses.Include(c => c.City).Where(a => a.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> UpdateAddress(CustomerAddress customerAddress)
        {
            if (customerAddress == null)
                return false;

            var currentAddress = await _foodsNowDbContext.CustomerAdresses.FirstOrDefaultAsync(c => c.Id == customerAddress.Id);

            if (currentAddress == null)
                return false;

            customerAddress.StreetAddress = currentAddress.StreetAddress;
            customerAddress.House = currentAddress.House;
            customerAddress.CityId = currentAddress.CityId;
            customerAddress.District = currentAddress.District;
            customerAddress.UnitNumber = currentAddress.UnitNumber;
            customerAddress.FloorNumber = currentAddress.FloorNumber;
            customerAddress.Notes = currentAddress.Notes;
            customerAddress.Tag = currentAddress.Tag;
            customerAddress.Latitude = currentAddress.Latitude;
            customerAddress.Longitude = currentAddress.Longitude;
            customerAddress.UpdatedDateTimeUtc = DateTime.UtcNow;
            customerAddress.UpdatedById = customerAddress.CustomerId;


            _foodsNowDbContext.CustomerAdresses.Update(customerAddress);

            await _foodsNowDbContext.SaveChangesAsync();

            return true;
        }

    }
}
