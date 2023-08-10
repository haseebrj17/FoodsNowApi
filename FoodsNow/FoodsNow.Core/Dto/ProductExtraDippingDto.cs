namespace FoodsNow.Core.Dto
{
    public class ProductExtraDippingDto
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraDippingPriceDto> Prices { get; set; } = new List<ProductExtraDippingPriceDto>();
    }

    public class ProductExtraDippingPriceDto
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }

    }


}
