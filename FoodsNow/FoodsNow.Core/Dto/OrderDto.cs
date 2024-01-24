using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class OrderDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public decimal TotalBill { get; set; }

        public int TotalItems { get; set; }

        public DateTime OrderDeliveryDateTime { get; set; }

        public string? Instructions { get; set; }

        public Guid CustomerId { get; set; }

        public Guid CustomerAddressId { get; set; }

        public CustomerDetailsDto CustomerDetails { get; set; } = null!;

        public Guid FranchiseId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public CustomerOrderedPackageDto CustomerOrderedPackage { get; set; } = null!;

        public List<OrderProductDto> OrderProducts { get; set; } = null!;

        public CustomerOrderPromoDto CustomerOrderPromo { get; set; } = null!;

        public CustomerOrderPaymentDto CustomerOrderPayment { get; set; } = null!;
    }

    public class CustomerDetailsDto
    {
        public string CustomerFullName { get; set; } = null!;

        public string CustomerEmailAddress { get; set; } = null!;

        public string CustomerContactNumber { get; set; } = null!;

        public CustomerAddressDetailDto CustomerAddressDetail { get; set; } = null!;
    }

    public class CustomerAddressDetailDto
    {
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

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public Guid CityId { get; set; }
    }

    public class CustomerOrderedPackageDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public Guid PackageId { get; set; }

        public string PackageName { get; set; } = null!;

        public int TotalNumberOfMeals { get; set; }

        public int NumberOfDays { get; set; }

        public Timings Timings { get; set; }

        public string MealzPerDay { get; set; } = null!;

        public int NumberOfWeeks { get; set; }
    }

    public class CustomerOrderPromoDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Type { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Percent { get; set; } = null!;
    }

    public class CustomerOrderPaymentDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string PaymentType { get; set; } = null!;

        public OrderType OrderType { get; set; }
    }

    public class OrderProductDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public string? EstimatedDeliveryTime { get; set; }

        public int? SpiceLevel { get; set; }

        public string IngredientSummary { get; set; } = null!;

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public List<OrderedProductExtraDippingDto> OrderedProductExtraDipping { get; set; } = null!;

        public List<OrderedProductExtraToppingDto> OrderedProductExtraTopping { get; set; } = null!;

        public OrderedProductSidesDto OrderedProductSides { get; set; } = null!;

        public OrderedProductDessertDto OrderedProductDessert { get; set; } = null!;

        public OrderedProductDrinksDto OrderedProductDrinks { get; set; } = null!;

        public List<OrderedProductChoicesDto> OrderedProductChoices { get; set; } = new List<OrderedProductChoicesDto>();
    }

    public class OrderedProductChoicesDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;
    }

    public class OrderedProductExtraDippingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class OrderedProductExtraToppingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class OrderedProductSidesDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class OrderedProductDessertDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class OrderedProductDrinksDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}