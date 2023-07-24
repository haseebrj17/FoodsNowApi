namespace FoodsNow.Core.Dto
{
    public class HomeDataDto
    {
        public Guid ClientId { get; set; }
        public Guid FranchiseId { get; set; }
        public List<BannerDto> Banners { get; set; } = new List<BannerDto>();
        public List<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }
}
