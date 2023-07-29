namespace FoodsNow.DbEntities.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public Guid ParentId { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
