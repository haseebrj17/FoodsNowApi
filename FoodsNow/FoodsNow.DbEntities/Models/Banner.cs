namespace FoodsNow.DbEntities.Models
{
    public class Banner : BaseEntity
    {
        public required string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; } = 0;
        public DateTime Validity { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
