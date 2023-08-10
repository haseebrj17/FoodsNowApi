namespace FoodsNow.Core.Dto
{
    public class ProductDataDto
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<ProductExtraDippingDto> ProductExtraDippings { get; set; } = new List<ProductExtraDippingDto>();
        public List<ProductExtraTroppingDto> ProductExtraTroppings { get; set; } = new List<ProductExtraTroppingDto>();
    }
}
