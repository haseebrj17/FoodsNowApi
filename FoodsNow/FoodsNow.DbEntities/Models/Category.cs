namespace FoodsNow.DbEntities.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string Cover { get; set; }
        public required string Thumbnail { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public bool IsVisibleOnDashboard { get; set; }
        public bool IsVisibleOnCheckOut { get; set; }
        public bool IsVisibleOnCart { get; set; }
        public bool IsBrand { get; set; }
        public bool IsActive { get; set; }
        public Guid? ParentId { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
