namespace FoodsNow.DbEntities.Models
{
    public class FranchiseTiming : BaseEntity
    {
        public int Day { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
