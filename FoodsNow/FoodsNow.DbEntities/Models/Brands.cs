namespace FoodsNow.DbEntities.Models
{
    public class Brands : BaseEntity
    {
        public required string Name { get; set; }
        public required string AppLogo { get; set; }
        public required string WebsiteLogo { get; set; }
        public bool IsActive { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
