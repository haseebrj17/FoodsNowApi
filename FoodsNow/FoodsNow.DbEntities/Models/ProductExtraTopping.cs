namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraTopping : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public required decimal Price { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
        public Guid BrandId { get; set; }
        public required Brand Brand { get; set; }
    }
}
