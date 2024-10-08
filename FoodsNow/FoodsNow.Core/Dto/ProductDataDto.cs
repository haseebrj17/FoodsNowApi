﻿namespace FoodsNow.Core.Dto
{
    public class ProductDataDto
    {
        public required ProductDto Product { get; set; }
        public List<ProductExtraDippingDto> ProductExtraDippings { get; set; } = new List<ProductExtraDippingDto>();
        public List<ProductExtraToppingDto> ProductExtraTroppings { get; set; } = new List<ProductExtraToppingDto>();
    }
}
