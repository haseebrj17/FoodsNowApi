namespace FoodsNow.DbEntities.Models
{
    public class City : BaseEntity
    {
        public required string Name { get; set; }
        public Guid StateId { get; set; }
        public required State State { get; set; }
    }
}
