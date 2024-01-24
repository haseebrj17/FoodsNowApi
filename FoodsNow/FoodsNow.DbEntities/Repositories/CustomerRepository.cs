using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> Add(Customer customer);
        Task<Customer> GetById(Guid customerId);
        Task<bool> VerifyPin(string pin, Guid customerId);
        Task<bool> DeleteMyAccount(Guid customerId);
        Task<Customer?> CustomerLogin(string emailAddress, string password);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public CustomerRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<Customer?> Add(Customer customer)
        {
            if (customer == null)
                return null;

            var existingCustomers = await _foodsNowDbContext.Customers
                                          .Where(c => c.ContactNumber == customer.ContactNumber)
                                          .ToListAsync();

            if (existingCustomers.Any(c => !c.IsDeleted))
                return null;

            customer.VerificationCode = GeneatePin();
            customer.CreatedDateTimeUtc = DateTime.UtcNow;
            customer.UpdatedDateTimeUtc = DateTime.UtcNow;
            customer.CreatedById = Guid.NewGuid();
            customer.UpdatedById = Guid.NewGuid();

            await _foodsNowDbContext.Customers.AddAsync(customer);

            await _foodsNowDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer?> CustomerLogin(string emailAddress, string password)
        {
            var customer = await _foodsNowDbContext.Customers.FirstOrDefaultAsync(c => c.EmailAddress == emailAddress && c.Password == password && c.IsActive && !c.IsDeleted);

            if (customer == null) return null;

            return customer;
        }

        public async Task<bool> DeleteMyAccount(Guid customerId)
        {
            var customer = await _foodsNowDbContext.Customers.FirstAsync(c => c.Id == customerId);

            customer.IsActive = false;

            customer.ContactNumber = "User removed his/her account";

            customer.IsDeleted = true;

            customer.FullName = "User removed his/her account";

            customer.EmailAddress = "User removed his/her account";

            customer.Password = "User removed his/her account";

            customer.UpdatedById = customer.Id;

            customer.UpdatedDateTimeUtc = DateTime.UtcNow;

            foreach (var address in customer.CustomerAddresses)
            {
                address.StreetAddress = "User removed his/her account";
                address.Notes = "User removed his/her account";
                address.House = "User removed his/her account";
                address.PostalCode = "User removed his/her account";
                address.UnitNumber = "User removed his/her account";
                address.FloorNumber = "User removed his/her account";
                address.Latitude = 0;
                address.Longitude = 0;

                _foodsNowDbContext.Customers.Update(customer);
            }

            await _foodsNowDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Customer> GetById(Guid customerId)
        {
            var customer = await _foodsNowDbContext.Customers.FirstAsync(c => c.Id == customerId);

            return customer;
        }

        public async Task<bool> VerifyPin(string pin, Guid customerId)
        {
            var customer = await _foodsNowDbContext.Customers.FirstOrDefaultAsync(c => c.VerificationCode == pin && c.Id == customerId);

            if (customer == null) return false;

            customer.IsNumberVerified = true;
            customer.UpdatedDateTimeUtc = DateTime.UtcNow;
            customer.UpdatedById = customerId;

            _foodsNowDbContext.Customers.Update(customer);

            await _foodsNowDbContext.SaveChangesAsync();

            return true;
        }

        private string GeneatePin()
        {
            return new Random().Next(1, 1000000).ToString("D6");
        }
    }
}