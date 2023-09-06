using AutoMapper;
using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _cityRepository = cityRepository;
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

        public async Task<bool> CustomerLogin(CustomerDto customer)
        {
            return await _customerRepository.CustomerLogin(customer.EmailAdress, customer.Password);
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

        public async Task<bool> VerifyPin(string pin, Guid customerId)
        {
            return await _customerRepository.VerifyPin(pin, customerId);
        }

    }
}
