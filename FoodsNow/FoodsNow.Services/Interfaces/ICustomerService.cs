using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;

namespace FoodsNow.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto>? AddCustomer(CustomerDto customer);        
        Task<bool> VerifyPin(string pin, Guid customerId);
        Task<bool> CustomerLogin(CustomerDto customer);
        Task<CustomerAddressDto?> AddAddress(CustomerAddressDto customer);
        Task<bool> UpdateAddress(CustomerAddressDto customer);

    }
}
