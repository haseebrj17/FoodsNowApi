namespace FoodsNow.Core.Dto
{
    public class ProductExtraTroppingDto
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraTroppingPriceDto> Prices { get; set; } = new List<ProductExtraTroppingPriceDto>();
    }

    public class ProductExtraTroppingPriceDto
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }

    }


}
