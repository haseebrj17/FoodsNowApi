using System;

namespace FoodsNow.Core.Dto
{
    public class ProductsDataDto
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<SubCategoryDto> Categories { get; set; } = new List<SubCategoryDto>();
    }
}
