namespace FoodsNow.DbEntities.Models
{
    public class State : BaseEntity
    {
        public required string Name { get; set; }
        public Guid CountryId { get; set; }
        public required Country Country { get; set; }
    }
}
