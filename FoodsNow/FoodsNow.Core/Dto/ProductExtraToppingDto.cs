namespace FoodsNow.Core.Dto
{
    public class ProductExtraToppingDto
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraToppingPriceDto> Prices { get; set; } = new List<ProductExtraToppingPriceDto>();
    }

    public class ProductExtraToppingPriceDto
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }

    }


}
