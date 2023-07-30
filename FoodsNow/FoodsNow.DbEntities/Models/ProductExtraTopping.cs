namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraTopping : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public required decimal Price { get; set; }
    }
}
