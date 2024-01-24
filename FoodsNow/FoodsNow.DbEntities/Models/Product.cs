using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FoodsNow.DbEntities.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Detail { get; set; } = null!;

        public string? EstimatedDeliveryTime { get; set; }

        public int Sequence { get; set; } = 0;

        public int? SpiceLevel { get; set; }

        public string Type { get; set; } = null!;

        [Required]
        public string IngredientSummary { get; set; } = null!;

        [Required]
        public string IngredientDetail { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public bool IsActive { get; set; }

        public Guid FranchiseId { get; set; }

        public bool ShowExtraTopping { get; set; }

        public bool ShowExtraDipping { get; set; }

        public List<ProductAllergy> ProductAllergy { get; set; } = new List<ProductAllergy>();

        public List<ProductPrice> ProductPrice { get; set; } = new List<ProductPrice>();

        public List<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();

        public Guid CategoryId { get; set; }

        public List<ProductExtraDipping> ProductExtraDipping { get; set; } = new List<ProductExtraDipping>();

        public List<ProductExtraTopping> ProductExtraTopping { get; set; } = new List<ProductExtraTopping>();

        public List<ProductChoices> ProductChoices { get; set; } = new List<ProductChoices>();
    }

    public class ProductAllergy : BaseEntity
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductPrice : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }

    public class ProductCategory : BaseEntity
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public string CategoryType { get; set; } = null!;
    }

    public class ProductChoices : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;
    }

    public class ProductExtraDipping : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public List<ProductExtraDippingAllergy> ProductExtraDippingAllergy { get; set; } = new List<ProductExtraDippingAllergy>();

        public List<ProductExtraDippingPrice> ProductExtraDippingPrice { get; set; } = new List<ProductExtraDippingPrice>();
    }

    public class ProductExtraDippingAllergy : BaseEntity
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraDippingPrice : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }

    public class ProductExtraTopping : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public List<ProductExtraToppingAllergy> ProductExtraToppingAllergy { get; set; } = new List<ProductExtraToppingAllergy>();

        public List<ProductExtraToppingPrice> ProductExtraToppingPrice { get; set; } = new List<ProductExtraToppingPrice>();
    }

    public class ProductExtraToppingAllergy : BaseEntity
    {
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraToppingPrice : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
