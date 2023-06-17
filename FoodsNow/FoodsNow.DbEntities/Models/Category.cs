namespace FoodsNow.DbEntities.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public Guid ParentId { get; set; }
    }
}
