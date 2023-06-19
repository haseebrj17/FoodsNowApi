namespace FoodsNow.DbEntities.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public required string Image { get; set; }
        public required decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool showExtraTropping { get; set; }
        public Guid BrandId { get; set; }
        public required Brand Brand { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
