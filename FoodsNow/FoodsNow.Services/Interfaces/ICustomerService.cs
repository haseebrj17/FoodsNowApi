using FoodsNow.Core.Dto;
using FoodsNow.Core.ResponseModels;
using FoodsNow.DbEntities.Models;

namespace FoodsNow.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto>? AddCustomer(CustomerDto customer);        
        Task<LoginResponse> VerifyPin(string pin, Guid customerId);
        Task<LoginResponse> CustomerLogin(CustomerDto customer);
        Task<CustomerAddressDto?> AddAddress(CustomerAddressDto customer);
        Task<List<CustomerAddress>> GetAllAddresses(Guid customerId);
        Task<bool> UpdateAddress(CustomerAddressDto customer);

    }
}
