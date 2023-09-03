﻿using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace FoodsNow.DbEntities.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> Add(Customer customer);
        Task<bool> VerifyPin(string pin, Guid customerId);
        Task<bool> CustomerLogin(string emailAdress, string password);
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

            if (await _foodsNowDbContext.Customers.AnyAsync(c => c.ContactNumber == customer.ContactNumber))
                return null;

            customer.VerificationCode = GeneatePin();
            customer.CreatedDateTimeUtc = DateTime.UtcNow;
            customer.UpdatedDateTimeUtc = DateTime.UtcNow;
            customer.CreatedById = Guid.NewGuid();//Todo: replace
            customer.UpdatedById = Guid.NewGuid();//Todo: replace

            await _foodsNowDbContext.Customers.AddAsync(customer);

            return customer;
        }

        public async Task<bool> CustomerLogin(string emailAdress, string password)
        {
            var customer = await _foodsNowDbContext.Customers.FirstOrDefaultAsync(c => c.EmailAdress == emailAdress && c.Password == password);

            if (customer == null) return false;

            return true;
        }

        public async Task<bool> VerifyPin(string pin, Guid customerId)
        {
            var customer = await _foodsNowDbContext.Customers.FirstOrDefaultAsync(c => c.VerificationCode == pin && c.Id == customerId);
            
            if (customer == null) return false;

            customer.IsNumberVerified = true;
            customer.UpdatedDateTimeUtc = DateTime.UtcNow;
            customer.UpdatedById = Guid.NewGuid();//Todo: replace

            _foodsNowDbContext.Customers.Update(customer);

            return true;
        }

        private string GeneatePin()
        {
            return new Random().Next(1, 1000000).ToString("D6");
        }
    }
}
