using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ContactNumber { get; set; } = null!;

        [Required]
        public string VerificationCode { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsNumberVerified { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid CityId { get; set; }

        public List<CustomerAddresses> CustomerAddresses { get; set; } = new List<CustomerAddresses>();

        public CustomerPromo CustomerPromo { get; set; } = null!;

        public CustomerPayment CustomerPayment { get; set; } = null!;

        public CustomerPassword CustomerPassword { get; set; } = null!;

        public List<CustomerDevice> CustomerDevice { get; set; } = new List<CustomerDevice>();
    }

    public class CustomerAddresses : BaseEntity
    {
        [Required]
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

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public Guid CityId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }

    public class CustomerPayment : BaseEntity
    {
        [Required]
        public string PaymentType { get; set; } = null!;

        [Required]
        public OrderType OrderType { get; set; }
    }

    public class CustomerPromo : BaseEntity
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Percent { get; set; } = null!;
    }

    public class CustomerDevice : BaseEntity
    {
        public string DeviceId { get; set; } = null!;

        public bool IsActive { get; set; }
    }

    public class CustomerPassword : BaseEntity
    {
        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }
}
