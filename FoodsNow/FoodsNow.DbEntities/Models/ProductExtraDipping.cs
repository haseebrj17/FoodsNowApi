namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraDipping : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public List<ProductExtraDippingAllergy>? Allergies { get; set; }
        public List<ProductExtraDippingPrice>? Prices { get; set; }
    }
}
