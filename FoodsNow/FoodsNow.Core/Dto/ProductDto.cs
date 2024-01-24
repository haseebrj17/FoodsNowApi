using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FoodsNow.Core.Dto
{
    public class ProductDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public string? EstimatedDeliveryTime { get; set; }

        public int Sequence { get; set; }

        public int? SpiceLevel { get; set; }

        public string? Type { get; set; }

        public string IngredientSummary { get; set; } = null!;

        public string IngredientDetail { get; set; } = null!;

        public string Image { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool ShowExtraTopping { get; set; }

        public bool ShowExtraDipping { get; set; }

        public List<ProductAllergyDto> ProductAllergy { get; set; } = null!;

        public List<ProductPriceDto> ProductPrice { get; set; } = null!;

        public List<ProductCategoryDto> ProductCategory { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public List<ProductExtraDippingDto> ProductExtraDipping { get; set; } = null!;

        public List<ProductExtraToppingDto> ProductExtraTopping { get; set; } = null!;

        public List<ProductChoicesDto> ProductChoices { get; set; } = new List<ProductChoicesDto>();
    }

    public class ProductAllergyDto
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductPriceDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }

    public class ProductCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string CategoryType { get; set; } = null!;
    }

    public class ProductChoicesDto
    {
        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;
    }

    public class ProductExtraDippingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public List<ProductExtraDippingAllergyDto> ProductExtraDippingAllergy { get; set; } = null!;

        public List<ProductExtraDippingPriceDto> ProductExtraDippingPrice { get; set; } = null!;
    }

    public class ProductExtraDippingAllergyDto
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraDippingPriceDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }

    public class ProductExtraToppingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public List<ProductExtraToppingAllergyDto> ProductExtraToppingAllergy { get; set; } = null!;

        public List<ProductExtraToppingPriceDto> ProductExtraToppingPrice { get; set; } = null!;
    }

    public class ProductExtraToppingAllergyDto
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraToppingPriceDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
