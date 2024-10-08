﻿namespace FoodsNow.Core.Dto
{
    public class ProductsDataDto
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<ProductExtraDippingDto> ProductExtraDippings { get; set; } = new List<ProductExtraDippingDto>();
        public List<ProductExtraToppingDto> ProductExtraTroppings { get; set; } = new List<ProductExtraToppingDto>();
    }
}
