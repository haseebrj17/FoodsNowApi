namespace FoodsNow.Core.Dto
{
    public class BannerDto
    {
        public required string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
