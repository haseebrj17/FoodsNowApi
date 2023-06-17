namespace FoodsNow.DbEntities.Models
{
    public class FranchiseHolidays:BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
