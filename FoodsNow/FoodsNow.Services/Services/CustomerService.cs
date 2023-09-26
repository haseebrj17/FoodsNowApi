using AutoMapper;
using FoodsNow.Core.Dto;
using FoodsNow.Core.ResponseModels;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IJwtTokenManager _jwtTokenManager;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository,
                ICityRepository cityRepository, IJwtTokenManager jwtTokenManager)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _cityRepository = cityRepository;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            if (customer == null) { return null; }

            var newCustomer = await _customerRepository.Add(customer);

            if (newCustomer == null) { return null; }

            return _mapper.Map<Customer, CustomerDto>(newCustomer);
        }

        public async Task<CustomerAddressDto> AddAddress(CustomerAddressDto addressDto)
        {
            var address = _mapper.Map<CustomerAddressDto, CustomerAddress>(addressDto);

            if (address == null) { return null; }

            var cityId = _cityRepository.GetCityIdByName(addressDto.CityName);

            if (cityId == Guid.Empty)
            {
                return null;
            }

            address.CityId = cityId.Value;

            var newAddress = await _customerAddressRepository.AddAddress(address);

            if (newAddress == null) { return null; }

            return _mapper.Map<CustomerAddress, CustomerAddressDto>(newAddress);
        }

        public async Task<LoginResponse> CustomerLogin(CustomerDto customer)
        {
            var customerDetails = await _customerRepository.CustomerLogin(customer.EmailAdress, customer.Password);

            if (customerDetails == null) { return new LoginResponse() { IsLoggedIn = false }; }

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerDetails);

            customerDto.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(customerDto);

            return new LoginResponse() { IsLoggedIn = true, Token = token, IsNumberVerified = customerDetails.IsNumberVerified };

        }

        public async Task<bool> UpdateAddress(CustomerAddressDto addressDto)
        {
            var address = _mapper.Map<CustomerAddressDto, CustomerAddress>(addressDto);

            var cityId = _cityRepository.GetCityIdByName(addressDto.CityName);

            if (cityId == Guid.Empty)
            {
                return false;
            }

            address.CityId = cityId.Value;

            if (address == null) { return false; }

            return await _customerAddressRepository.UpdateAddress(address);
        }

        public async Task<LoginResponse> VerifyPin(string pin, Guid customerId)
        {
            var isVerified = await _customerRepository.VerifyPin(pin, customerId);

            if (!isVerified)
            {
                return new LoginResponse() { IsLoggedIn = false, IsNumberVerified = false };
            }

            var customer = await _customerRepository.GetById(customerId);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);

            customerDto.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(customerDto);

            return new LoginResponse() { IsLoggedIn = true, Token = token, IsNumberVerified = customer.IsNumberVerified };
        }

        public async Task<List<CustomerAddressDto>> GetAllAddresses(Guid customerId)
        {
            var addresses = _mapper.Map<List<CustomerAddress>, List<CustomerAddressDto>>(await _customerAddressRepository.GetAllAddresses(customerId));

            foreach (var address in addresses)
            {
                address.CityName = address.City.Name;
            }
            return addresses;
        }
    }
}
