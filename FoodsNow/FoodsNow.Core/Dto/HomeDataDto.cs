﻿namespace FoodsNow.Core.Dto
{
    public class HomeDataDto
    {
        public Guid ClientId { get; set; }
        public Guid FranchiseId { get; set; }
        public List<BannerDto> Banners { get; set; } = new List<BannerDto>();
        public List<CategoryDto> Brands { get; set; } = new List<CategoryDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
