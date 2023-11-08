using AutoMapper;
using Azure;
using Azure.Communication.Sms;
using FoodsNow.Core;
using FoodsNow.Core.Dto;
using FoodsNow.Core.RequestModels;
using FoodsNow.Core.ResponseModels;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;
using System.Net.Mail;
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

            var response = _mapper.Map<Customer, CustomerDto>(newCustomer);

            return response;
        }

        private async Task SendSms(Customer customer)
        {
            var connectionString = "endpoint=https://foodsnow-communication-service.germany.communication.azure.com/;accesskey=LEcrgqBVfxG+wF4faUI+r8z/0j9MrK+LaR93onm+le5ZlTDO8y5PbeVyeJIEtCBD1fgYih59zwFGZ1i/vPdBng==";
            var smsClient = new SmsClient(connectionString);
            var sendResult = await smsClient.SendAsync(
                from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                to: customer.ContactNumber,
                message: customer.VerificationCode);
            //Console.WriteLine($"Sms id: {sendResult.}");
        }

        public async Task<CustomerAddressDto> AddAddress(CustomerAddressDto addressDto)
        {
            var address = _mapper.Map<CustomerAddressDto, CustomerAddress>(addressDto);

            if (address == null) { return null; }

            var cityId = _cityRepository.GetCityIdByName(addressDto.CityName);

            if (cityId == null || cityId == Guid.Empty)
            {
                cityId = await _cityRepository.AddCity(addressDto.CityName, addressDto.StateName, addressDto.CountryName);
            }

            address.CityId = cityId.Value;

            var newAddress = await _customerAddressRepository.AddAddress(address);

            if (newAddress == null) { return null; }

            return _mapper.Map<CustomerAddress, CustomerAddressDto>(newAddress);
        }

        public async Task<LoginResponse> CustomerLogin(LoginRequestModel loginRequest)
        {
            var customerDetails = await _customerRepository.CustomerLogin(loginRequest.EmailAdress, loginRequest.Password);

            if (customerDetails == null) { return new LoginResponse() { IsLoggedIn = false }; }

            var currentAppUser = _mapper.Map<Customer, CurrentAppUser>(customerDetails);

            currentAppUser.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);

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

            var currentAppUser = _mapper.Map<Customer, CurrentAppUser>(customer);

            currentAppUser.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);

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

        public async Task<bool> DeleteMyAccount(Guid customerId)
        {
            return await _customerRepository.DeleteMyAccount(customerId);
        }
    }
}
