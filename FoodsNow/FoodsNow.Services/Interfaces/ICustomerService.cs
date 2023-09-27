using FoodsNow.Core.Dto;
using FoodsNow.Core.RequestModels;
using FoodsNow.Core.ResponseModels;

namespace FoodsNow.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto>? AddCustomer(CustomerDto customer);        
        Task<LoginResponse> VerifyPin(string pin, Guid customerId);
        Task<LoginResponse> CustomerLogin(LoginRequestModel customer);
        Task<CustomerAddressDto?> AddAddress(CustomerAddressDto customer);
        Task<List<CustomerAddressDto>> GetAllAddresses(Guid customerId);
        Task<bool> UpdateAddress(CustomerAddressDto customer);

    }
}
