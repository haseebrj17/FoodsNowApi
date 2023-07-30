namespace FoodsNow.DbEntities.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string AppLogo { get; set; }
        public required string WebsiteLogo { get; set; }
        public bool IsVisibleOnDashboard { get; set; }
        public bool IsVisibleOnCheckOut { get; set; }
        public bool IsVisibleOnCart { get; set; }
        public bool IsActive { get; set; }
        public Guid? ParentId { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
