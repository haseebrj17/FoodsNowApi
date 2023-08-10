namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraDippingPrice : BaseEntity
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductExtraDippingId { get; set; }
        public required ProductExtraDipping ProductExtraDipping { get; set; }
        
    }
}
