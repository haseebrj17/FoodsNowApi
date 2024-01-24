using FoodsNow.Core.Dto;
using System;
using System.Collections.Generic;

namespace FoodsNow.Core.Dto
{
    public class HomeDataDto
    {
        public Guid ClientId { get; set; }
        public Guid FranchiseId { get; set; }
        public List<BannerDto> Banners { get; set; } = new List<BannerDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryDto> Brands { get; set; } = new List<CategoryDto>();
        public List<SubCategoryDto> AllSubCategories { get; set; } = new List<SubCategoryDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
