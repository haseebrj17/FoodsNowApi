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
        public bool showExtraDipping { get; set; }
        public List<ProductPriceDto> Prices { get; set; } = new List<ProductPriceDto>();
    }

    public class ProductPriceDto
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }

    }
}
