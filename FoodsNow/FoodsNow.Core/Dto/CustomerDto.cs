using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class CustomerDto
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        public string FullName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public bool IsNumberVerified { get; set; }

        public bool IsEmailVerified { get; set; }

        public List<CustomerAddressDto> CustomerAddresses { get; set; } = null!;

        public CustomerPromoDto CustomerPromo { get; set; } = null!;

        public CustomerPromoDto CustomerPayment { get; set; } = null!;

        public string Code { get; set; } = null!;

        public UserRole UserRole { get; set; }

        public Guid CityId { get; set; }

        public CustomerPasswordDto CustomerPassword { get; set; } = null!;

        public List<CustomerDeviceDto> CustomerDevice { get; set; } = new List<CustomerDeviceDto>();
    }

    public class CustomerAddressDto
    {
        public Guid Id { get; set; }

        public string StreetAddress { get; set; } = null!;

        public string House { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string CityName { get; set; } = null!;

        public string District { get; set; } = null!;

        public string UnitNumber { get; set; } = null!;

        public string FloorNumber { get; set; } = null!;

        public string StateName { get; set; } = null!;

        public string CountryName { get; set; } = null!;

        public string Notes { get; set; } = null!;

        public bool IsDefault { get; set; }

        public string Tag { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public Guid CityId { get; set; }

        public Guid CustomerId { get; set; }
    }

    public class CustomerDeviceDto
    {
        public string DeviceId { get; set; } = null!;

        public bool IsActive { get; set; }
    }

    public class CustomerPasswordDto
    {
        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }

    public class CustomerPaymentDto
    {
        public string PaymentType { get; set; } = null!;

        public OrderType OrderType { get; set; }
    }

    public class CustomerPromoDto
    {
        public string Type { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Percent { get; set; } = null!;
    }
}
