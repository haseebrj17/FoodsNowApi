namespace FoodsNow.Core.Dto
{
    public class ProductDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public string? EstimatedDeliveryTime { get; set; }
        public int? SpiceLevel { get; set; }
        public required string IngredientSummary { get; set; }
        public required string IngredientDetail { get; set; }
        public required string Image { get; set; }
        public bool showExtraTropping { get; set; }
    }
}
