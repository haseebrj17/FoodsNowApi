namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraTopping : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraToppingAllergy>? Allergies { get; set; }
        public List<ProductExtraToppingPrice>? Prices { get; set; }
    }
}