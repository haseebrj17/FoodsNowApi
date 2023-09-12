namespace FoodsNow.Core.Dto
{
    public class ProductExtraDippingDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraDippingPriceDto> Prices { get; set; } = new List<ProductExtraDippingPriceDto>();

        public List<ProductAllergyDto> Allergies { get; set; } = new List<ProductAllergyDto>();
    }

    public class ProductExtraDippingPriceDto
    {
        public required Guid Id { get; set; }
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }

    }


}
