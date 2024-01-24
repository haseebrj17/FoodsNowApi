using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public decimal TotalBill { get; set; }

        [Required]
        public int TotalItems { get; set; }

        [Required]
        public DateTime OrderDeliveryDateTime { get; set; }

        public string? Instructions { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid CustomerAddressId { get; set; }

        [Required]
        public CustomerDetails CustomerDetails { get; set; } = null!;

        [Required]
        public Guid FranchiseId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public CustomerOrderPromo CustomerOrderPromo { get; set; } = null!;

        public CustomerOrderPayment CustomerOrderPayment { get; set; } = null!;

        public List<CustomerDevice> CustomerDevice { get; set; } = new List<CustomerDevice>();

        public List<OrderProducts>? OrderProducts { get; set; } = new List<OrderProducts>();
    }

    public class CustomerDetails : BaseEntity
    {

        [Required]
        public string CustomerFullName { get; set; } = null!;

        [Required]
        public string CustomerEmailAddress { get; set; } = null!;

        [Required]
        public string CustomerContactNumber { get; set; } = null!;

        [Required]
        public CustomerAddressDetail CustomerAddressDetail { get; set; } = null!;
    }

    public class CustomerAddressDetail : BaseEntity
    {
        [Required]
        public string StreetAddress { get; set; } = null!;

        public string? House { get; set; }

        public string? PostalCode { get; set; }

        public string? CityName { get; set; }

        public string? District { get; set; }

        public string? UnitNumber { get; set; }

        public string? FloorNumber { get; set; }

        public string? StateName { get; set; }

        public string? CountryName { get; set; }

        public string? Notes { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public Guid CityId { get; set; }
    }

    public class CustomerOrderPayment : BaseEntity
    {
        [Required]
        public string PaymentType { get; set; } = null!;

        [Required]
        public OrderType OrderType { get; set; }
    }

    public class CustomerOrderPromo : BaseEntity
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Percent { get; set; } = null!;
    }

    public class OrderProducts : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Detail { get; set; } = null!;

        public string? EstimatedDeliveryTime { get; set; }

        public int? SpiceLevel { get; set; }

        [Required]
        public string IngredientSummary { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public List<OrderedProductExtraDipping> OrderedProductExtraDipping { get; set; } = new List<OrderedProductExtraDipping>();

        public List<OrderedProductExtraTopping> OrderedProductExtraTopping { get; set; } = new List<OrderedProductExtraTopping>();

        public List<OrderedProductChoices> OrderedProductChoices { get; set; } = new List<OrderedProductChoices>();
    }

    public class OrderedProductChoices : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;
    }

    public class OrderedProductExtraDipping : BaseEntity
    {
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }

    public class OrderedProductExtraTopping : BaseEntity
    {
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
