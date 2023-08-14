namespace FoodsNow.DbEntities.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public string? EstimatedDeliveryTime { get; set; }
        public int Sequence { get; set; } = 0;
        public int? SpiceLevel { get; set; }
        public required string IngredientSummary { get; set; }
        public required string IngredientDetail { get; set; }
        public required string Image { get; set; }        
        public bool IsActive { get; set; }
        public bool showExtraTropping { get; set; }
        public bool showExtraDipping { get; set; }
        public List<ProductAllergy>? Allergies { get; set; }        
        public List<ProductPrice>? Prices { get; set; }

    }
}
